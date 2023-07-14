using Application.Abstractions.Services;
using MediatR;

namespace Application.Features.Commands.HotelProduct.RemoveHotelProductItem
{
    public class RemoveHotelProductItemCommandHandler : IRequestHandler<RemoveHotelProductItemCommandRequest, RemoveHotelProductItemCommandResponse>
    {
        readonly IHotelProductService _hotelProductService;

        public RemoveHotelProductItemCommandHandler(IHotelProductService hotelProductService)
        {
            _hotelProductService = hotelProductService;
        }
        public async Task<RemoveHotelProductItemCommandResponse> Handle(RemoveHotelProductItemCommandRequest request, CancellationToken cancellationToken)
        {
            await _hotelProductService.RemoveHotelProductItemAsync(request.HotelProductItemId);
            return new();
        }
    }
}
