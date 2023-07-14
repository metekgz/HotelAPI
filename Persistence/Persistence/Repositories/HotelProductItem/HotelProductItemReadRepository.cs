using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class HotelProductItemReadRepository : ReadRepository<HotelProductItem>, IHotelProductItemReadRepository
    {
        public HotelProductItemReadRepository(HotelAPIDbContext context) : base(context)
        {
        }
    }
}
