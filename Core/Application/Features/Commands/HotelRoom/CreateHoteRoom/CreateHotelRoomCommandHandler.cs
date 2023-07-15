using Application.Abstractions.Hubs;
using Application.Features.Commands.Product.CreateProduct;
using Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.HotelRoom.CreateHoteRoom
{
    public class CreateHotelRoomCommandHandler : IRequestHandler<CreateHotelRoomCommandRequest, CreateHotelRoomCommandResponse>
    {
        readonly IHotelRoomWriteRepository _hotelRoomWriteRepository;
        readonly ILogger<CreateHotelRoomCommandHandler> _logger;

        public CreateHotelRoomCommandHandler(IHotelRoomWriteRepository hotelRoomWriteRepository, ILogger<CreateHotelRoomCommandHandler> logger)
        {
            _hotelRoomWriteRepository = hotelRoomWriteRepository;
            _logger = logger;
        }

        public async Task<CreateHotelRoomCommandResponse> Handle(CreateHotelRoomCommandRequest request, CancellationToken cancellationToken)
        {
            await _hotelRoomWriteRepository.AddAsync(new()
            {
                RoomName = request.RoomName,
                Price = request.Price,
                Description = request.Description,
            });
            await _hotelRoomWriteRepository.SaveAsync();
            return new();
        }
    }
}
