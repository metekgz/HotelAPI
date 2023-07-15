using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.HotelRoom.UpdateHoteRoom
{
    public class UpdateHotelRoomCommandHandler : IRequestHandler<UpdateHotelRoomCommandRequest, UpdateHotelRoomCommandResponse>
    {
        IHotelRoomReadRepository _hotelRoomReadRepository;
        IHotelRoomWriteRepository _hotelRoomWriteRepository;

        public UpdateHotelRoomCommandHandler(IHotelRoomReadRepository hotelRoomReadRepository, IHotelRoomWriteRepository hotelRoomWriteRepository)
        {
            _hotelRoomReadRepository = hotelRoomReadRepository;
            _hotelRoomWriteRepository = hotelRoomWriteRepository;
        }


        public async Task<UpdateHotelRoomCommandResponse> Handle(UpdateHotelRoomCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.HotelRoom hotelRoom = await _hotelRoomReadRepository.GetByIdAsync(request.Id);
            hotelRoom.RoomName = request.RoomName;
            hotelRoom.Price = request.Price;
            hotelRoom.Description = request.Description;
            await _hotelRoomWriteRepository.SaveAsync();
            return new();
        }
    }
}
