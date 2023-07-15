using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class HotelRoomReadRepository : ReadRepository<HotelRoom>, IHotelRoomReadRepository
    {
        public HotelRoomReadRepository(HotelAPIDbContext context) : base(context)
        {
        }
    }
}
