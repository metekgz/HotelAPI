using Application.Abstractions.Services;
using Application.Abstractions.Token;
using Application.DTOs;
using Application.Exceptions;
using Domain.Entities.Identity;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly SignInManager<AppUser> _signInManager;
        readonly IUserService _userService;
        public AuthService(UserManager<AppUser> userManager, ITokenHandler tokenHandler, SignInManager<AppUser> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _userService = userService;
        }


        public async Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { "UI tarafında app.module'de providers kısmındaki yazdığım Client Id ile aynı Id buraya yazılmalı" },
            };

            // doğrulama 
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

            // dışarıdan gelen kullanıcı bilgilerini kaydetme işlemi
            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");

            AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = payload.Email,
                        UserName = payload.Email,
                        NameSurname = payload.Name,
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;

                }
            }
            if (result)
            {
                await _userManager.AddLoginAsync(user, info);
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime,user);
                await _userService.UpdateRefleshToken(token.RefleshToken, user, token.Expiration, 30);
                return token;
            }
            else
                throw new Exception("Doğrulama Geçersiz");

        }

        public async Task<Token> LoginAsync(string userNameOrEmail, string password, int accessTokenLifeTime)
        {
            AppUser user = await _userManager.FindByNameAsync(userNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(userNameOrEmail);
            if (user == null)
                throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime,user);
                await _userService.UpdateRefleshToken(token.RefleshToken, user, token.Expiration, 30);
                return token;
            }
            else
                throw new AuthenticationErrorException();
        }

        public async Task<Token> RefleshTokenLoginAsync(string refleshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefleshToken == refleshToken);

            if (user != null && user?.RefleshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(15,user);
                await _userService.UpdateRefleshToken(token.RefleshToken, user, token.Expiration, 30);
                return token;
            }
            else
                throw new NotFoundUserException();
        }
    }
}
