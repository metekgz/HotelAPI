using Application.Features.Commands.HotelProduct.AddItemToHotelProduct;
using Application.Features.Commands.HotelProduct.RemoveHotelProductItem;
using Application.Features.Commands.HotelProduct.UpdateQuantity;
using Application.Features.Queries.HotelProduct.GetHotelProductItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class HotelProducts : ControllerBase
    {
        readonly IMediator _mediator;

        public HotelProducts(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotelProductItems([FromQuery]GetHotelProductItemsQueryRequest getHotelProductItemsQueryRequest)
        {
            List<GetHotelProductItemsQueryResponse> response = await _mediator.Send(getHotelProductItemsQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToHotelProduct (AddItemToHotelProductCommandRequest addItemToHotelProductCommandRequest)
        {
            AddItemToHotelProductCommandResponse response = await _mediator.Send(addItemToHotelProductCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest updateQuantityCommandRequest)
        {
            UpdateQuantityCommandResponse response = await _mediator.Send(updateQuantityCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{HotelProductItemId}")]
        public async Task<IActionResult> RemoveHotelProductItem([FromRoute]RemoveHotelProductItemCommandRequest removeHotelProductItemCommandRequest)
        {
            RemoveHotelProductItemCommandResponse response = await _mediator.Send(removeHotelProductItemCommandRequest);
            return Ok(response);
        }
    }
}
