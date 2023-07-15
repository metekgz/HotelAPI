﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.HotelRoom.RemoveHoteRoom
{
    public class RemoveHotelRoomCommandRequest:IRequest<RemoveHotelRoomCommandResponse>
    {
        public string Id { get; set; }
    }
}
