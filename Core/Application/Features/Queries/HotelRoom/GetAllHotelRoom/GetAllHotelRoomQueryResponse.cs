using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.HotelRoom.GetAllHotelRoom
{
    public class GetAllHotelRoomQueryResponse
    {
        public int TotalCount { get; set; }
        public object HotelRooms { get; set; }
    }
}
