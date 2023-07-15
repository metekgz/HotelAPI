using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class HotelRoomWriteRepository : WriteRepository<HotelRoom>, IHotelRoomWriteRepository
    {
        public HotelRoomWriteRepository(HotelAPIDbContext context) : base(context)
        {
        }
    }
}
