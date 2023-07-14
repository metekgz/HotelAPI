using Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.HotelProduct.GetHotelProductItems
{
    public class GetHotelProductItemsQueryHandler : IRequestHandler<GetHotelProductItemsQueryRequest, List<GetHotelProductItemsQueryResponse>>
    {
        readonly IHotelProductService _hotelProductService;

        public GetHotelProductItemsQueryHandler(IHotelProductService hotelProductService)
        {
            _hotelProductService = hotelProductService;
        }
        public async Task<List<GetHotelProductItemsQueryResponse>> Handle(GetHotelProductItemsQueryRequest request, CancellationToken cancellationToken)
        {
            var hotelProductItems = await _hotelProductService.GetHotelProductItemsAsync();
            return hotelProductItems.Select(hp=>new GetHotelProductItemsQueryResponse
            {
                HotelProductItemId = hp.Id.ToString(),
                Name = hp.Product.Name,
                Price = (int)hp.Product.Price,
                Quantity = hp.Quantity
            }).ToList();
        }
    }
}
