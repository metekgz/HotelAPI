using Application.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private IRoomWriteRepository _roomWriteRepository;
        readonly private IRoomReadRepository _roomReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;


        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IRoomWriteRepository roomWriteRepository, ICustomerWriteRepository customerWriteRepository, IRoomReadRepository roomReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _roomWriteRepository = roomWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _roomReadRepository = roomReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
