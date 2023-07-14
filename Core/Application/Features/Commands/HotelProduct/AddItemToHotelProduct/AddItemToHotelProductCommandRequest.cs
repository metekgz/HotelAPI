using MediatR;

namespace Application.Features.Commands.HotelProduct.AddItemToHotelProduct
{
    public class AddItemToHotelProductCommandRequest:IRequest<AddItemToHotelProductCommandResponse>
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
