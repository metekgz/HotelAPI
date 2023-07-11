using MediatR;

namespace Application.Features.Commands.AppUser.RefleshTokenLogin
{
    public class RefleshTokenLoginCommandRequest:IRequest<RefleshTokenLoginCommandResponse>
    {
        public string RefleshToken { get; set; }
    }
}
