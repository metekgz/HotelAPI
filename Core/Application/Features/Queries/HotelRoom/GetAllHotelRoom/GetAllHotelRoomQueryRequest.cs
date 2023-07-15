using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.HotelRoom.GetAllHotelRoom
{
    public class GetAllHotelRoomQueryRequest:IRequest<GetAllHotelRoomQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
