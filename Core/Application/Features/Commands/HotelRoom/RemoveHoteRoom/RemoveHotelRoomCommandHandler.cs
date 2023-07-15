using Application.Features.Commands.Product.RemoveProduct;
using Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.HotelRoom.RemoveHoteRoom
{
    public class RemoveHotelRoomCommandHandler : IRequestHandler<RemoveHotelRoomCommandRequest, RemoveHotelRoomCommandResponse>
    {
        readonly IHotelRoomWriteRepository _hotelRoomWriteRepository;

        public RemoveHotelRoomCommandHandler(IHotelRoomWriteRepository hotelRoomWriteRepository, ILogger<RemoveHotelRoomCommandHandler> logger)
        {
            _hotelRoomWriteRepository = hotelRoomWriteRepository;
        }

        public async Task<RemoveHotelRoomCommandResponse> Handle(RemoveHotelRoomCommandRequest request, CancellationToken cancellationToken)
        {
            await _hotelRoomWriteRepository.RemoveAsync(request.Id);
            await _hotelRoomWriteRepository.SaveAsync();
            return new();
        }
    }
}
