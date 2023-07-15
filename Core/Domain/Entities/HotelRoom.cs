using Domain.Entities.Common;

namespace Domain.Entities
{
    public class HotelRoom:BaseEntity
    {
        public string RoomName { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }

    }
}
