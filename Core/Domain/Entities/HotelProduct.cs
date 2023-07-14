using Domain.Entities.Common;
using Domain.Entities.Identity;

namespace Domain.Entities
{
    public class HotelProduct:BaseEntity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public Room Room { get; set; }
        public ICollection<HotelProductItem> HotelProductItems { get; set; }
    }
}
