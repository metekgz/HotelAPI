using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class HotelProductWriteRepository : WriteRepository<HotelProduct>, IHotelProductWriteRepository
    {
        public HotelProductWriteRepository(HotelAPIDbContext context) : base(context)
        {
        }
    }
}
