using Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.HotelProduct.UpdateQuantity
{
    public class UpdateQuantityCommandHandler : IRequestHandler<UpdateQuantityCommandRequest, UpdateQuantityCommandResponse>
    {
        readonly IHotelProductService _hotelProductService;

        public UpdateQuantityCommandHandler(IHotelProductService hotelProductService)
        {
            _hotelProductService = hotelProductService;
        }
        public async Task<UpdateQuantityCommandResponse> Handle(UpdateQuantityCommandRequest request, CancellationToken cancellationToken)
        {
            await _hotelProductService.UpdateQuantityAsync(new()
            {
                HotelProductId = request.HotelProductItemId,
                Quantity = request.Quantity,
            });
            return new();
        }
    }
}
