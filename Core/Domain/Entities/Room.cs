using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Room : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Description { get; set; }

        public HotelProduct HotelProduct { get; set; }

        // room ve product arasındaki ilişki
        // bir room'ın birden fazla product'ı olduğunu ifade eder
        public ICollection<Product> Products { get; set; }

        // bir room'ın birden fazla customer'ı olamaz çünkü tek bir oda birden fazla müşteriye gitmez
        public Customer Customer { get; set; }
    }
}
