using Application.Features.Queries.Product.GetAllProduct;
using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.HotelRoom.GetAllHotelRoom
{
    public class GetAllHotelRoomQueryHandler : IRequestHandler<GetAllHotelRoomQueryRequest, GetAllHotelRoomQueryResponse>
    {
        readonly IHotelRoomReadRepository _hotelRoomReadRepository;

        public GetAllHotelRoomQueryHandler(IHotelRoomReadRepository hotelRoomReadRepository)
        {
            _hotelRoomReadRepository = hotelRoomReadRepository;
        }

        public async Task<GetAllHotelRoomQueryResponse> Handle(GetAllHotelRoomQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _hotelRoomReadRepository.GetAll(false).Count();
            // sayflardaki gösterilecek data için skip kullandım
            // örneğin 2-10 aralığı için 20 tane data getir
            var hotelRooms = _hotelRoomReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).Select(p => new
            {
                p.Id,
                p.RoomName,
                p.Description,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate

            }).ToList();

            var response = new GetAllHotelRoomQueryResponse
            {
                HotelRooms = hotelRooms,
                TotalCount = totalCount
            };

            return await Task.FromResult(response);
        }
    }
}
