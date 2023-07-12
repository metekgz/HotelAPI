using Application.Abstractions.Services;
using Application.DTOs.User;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;
        readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IUserService userService, ILogger<CreateUserCommandHandler> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                NameSurname = request.NameSurname,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                UserName = request.UserName
            });
            _logger.LogInformation("Yeni User Eklendi");
            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded,
            };
        }
    }
}
