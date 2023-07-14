using Domain.Entities.Common;

namespace Domain.Entities
{
    public class HotelProductItem : BaseEntity
    {
        public Guid HotelProductId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public HotelProduct HotelProduct { get; set; }
        public Product Product { get; set; }
    }
}
