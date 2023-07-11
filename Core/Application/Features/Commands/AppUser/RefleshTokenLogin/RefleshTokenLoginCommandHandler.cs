using Application.Abstractions.Services;
using Application.DTOs;
using MediatR;

namespace Application.Features.Commands.AppUser.RefleshTokenLogin
{
    public class RefleshTokenLoginCommandHandler : IRequestHandler<RefleshTokenLoginCommandRequest, RefleshTokenLoginCommandResponse>
    {
        readonly IAuthService _authService;

        public RefleshTokenLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RefleshTokenLoginCommandResponse> Handle(RefleshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            Token token = await _authService.RefleshTokenLoginAsync(request.RefleshToken);
            return new()
            {
                Token = token,
            };
        }
    }
}
