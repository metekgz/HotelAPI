using Application.Features.Commands.HotelRoom.CreateHoteRoom;
using Application.Features.Commands.HotelRoom.RemoveHoteRoom;
using Application.Features.Commands.HotelRoom.UpdateHoteRoom;
using Application.Features.Commands.Product.CreateProduct;
using Application.Features.Commands.Product.RemoveProduct;
using Application.Features.Commands.Product.UpdateProduct;
using Application.Features.Commands.ProductImageFile.UploadProductImage;
using Application.Features.Queries.HotelRoom.GetAllHotelRoom;
using Application.Features.Queries.Product.GetAllProduct;
using Application.Features.Queries.Product.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRooms : ControllerBase
    {
        readonly IMediator _mediator;

        public HotelRooms(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllHotelRoomQueryRequest getAllHotelRoomQueryRequest)
        {
            GetAllHotelRoomQueryResponse response = await _mediator.Send(getAllHotelRoomQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Post(CreateHotelRoomCommandRequest createHotelRoomCommandRequest)
        {
            CreateHotelRoomCommandResponse response = await _mediator.Send(createHotelRoomCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Put([FromBody] UpdateHotelRoomCommandRequest updateHotelRoomCommandRequest)
        {
            UpdateHotelRoomCommandResponse response = await _mediator.Send(updateHotelRoomCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] RemoveHotelRoomCommandRequest removeHotelRoomCommandRequest)
        {
            RemoveHotelRoomCommandResponse response = await _mediator.Send(removeHotelRoomCommandRequest);
            return Ok();
        }
    }
}
