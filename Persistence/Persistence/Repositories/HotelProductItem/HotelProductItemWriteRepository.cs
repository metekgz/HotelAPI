using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class HotelProductItemWriteRepository : WriteRepository<HotelProductItem>, IHotelProductItemWriteRepository
    {
        public HotelProductItemWriteRepository(HotelAPIDbContext context) : base(context)
        {
        }
    }
}
