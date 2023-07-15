using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.HotelRoom.CreateHoteRoom
{
    public class CreateHotelRoomCommandRequest:IRequest<CreateHotelRoomCommandResponse>
    {
        public string RoomName { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
    }
}
