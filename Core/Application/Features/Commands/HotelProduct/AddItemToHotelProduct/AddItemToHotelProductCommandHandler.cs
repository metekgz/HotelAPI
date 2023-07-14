using Application.Abstractions.Services;
using MediatR;

namespace Application.Features.Commands.HotelProduct.AddItemToHotelProduct
{
    public class AddItemToHotelProductCommandHandler : IRequestHandler<AddItemToHotelProductCommandRequest, AddItemToHotelProductCommandResponse>
    {
        readonly IHotelProductService _hotelProductService;

        public AddItemToHotelProductCommandHandler(IHotelProductService hotelProductService)
        {
            _hotelProductService = hotelProductService;
        }

        public async Task<AddItemToHotelProductCommandResponse> Handle(AddItemToHotelProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _hotelProductService.AddItemToHotelProductAsync(new()
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity
            });
            return new();
        }
    }
}
