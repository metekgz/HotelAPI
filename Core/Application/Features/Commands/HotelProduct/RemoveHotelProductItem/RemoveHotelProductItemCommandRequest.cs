using MediatR;

namespace Application.Features.Commands.HotelProduct.RemoveHotelProductItem
{
    public class RemoveHotelProductItemCommandRequest:IRequest<RemoveHotelProductItemCommandResponse>
    {
        public string HotelProductItemId { get; set; }
    }
}
