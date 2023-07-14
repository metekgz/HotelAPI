using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class HotelProductReadRepository : ReadRepository<HotelProduct>, IHotelProductReadRepository
    {
        public HotelProductReadRepository(HotelAPIDbContext context) : base(context)
        {
        }
    }
}
