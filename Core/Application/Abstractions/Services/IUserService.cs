using Application.DTOs.User;
using Domain.Entities.Identity;

namespace Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
        Task UpdateRefleshToken(string refleshToken,AppUser user,DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
