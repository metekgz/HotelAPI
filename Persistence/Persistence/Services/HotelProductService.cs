using Application.Abstractions.Services;
using Application.Repositories;
using Application.ViewModels.HotelProducts;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services
{
    public class HotelProductService : IHotelProductService
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        readonly IRoomReadRepository _roomReadRepository;
        readonly IHotelProductWriteRepository _hotelProductWriteRepository;
        readonly IHotelProductItemWriteRepository _hotelProductItemWriteRepository;
        readonly IHotelProductItemReadRepository _hotelProductItemReadRepository;
        readonly IHotelProductReadRepository _hotelProductReadRepository;

        public HotelProductService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IRoomReadRepository roomReadRepository, IHotelProductWriteRepository hotelProductWriteRepository, IHotelProductItemWriteRepository hotelProductItemWriteRepository, IHotelProductItemReadRepository hotelProductItemReadRepository, IHotelProductReadRepository hotelProductReadRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _roomReadRepository = roomReadRepository;
            _hotelProductWriteRepository = hotelProductWriteRepository;
            _hotelProductItemWriteRepository = hotelProductItemWriteRepository;
            _hotelProductItemReadRepository = hotelProductItemReadRepository;
            _hotelProductReadRepository = hotelProductReadRepository;
        }

        private async Task<HotelProduct?> ContextUser()
        {
            var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(username))
            {
                AppUser? user = await _userManager.Users.Include(u => u.HotelProducts).FirstOrDefaultAsync(u => u.UserName == username);
                var _hotelProduct = from hotelProduct in user.HotelProducts
                                    join room in _roomReadRepository.Table
                                    on hotelProduct.Id equals room.Id into HotelProductRooms
                                    from room in HotelProductRooms.DefaultIfEmpty()
                                    select new
                                    {
                                        HotelProduct = hotelProduct,
                                        Room = room
                                    };

                HotelProduct? targetHotelProduct = null;
                if (_hotelProduct.Any(h => h.Room is null))
                {
                    targetHotelProduct = _hotelProduct.FirstOrDefault(h => h.Room is null)?.HotelProduct;
                }
                else
                {
                    targetHotelProduct = new();
                    user.HotelProducts.Add(targetHotelProduct);
                }
                await _hotelProductWriteRepository.SaveAsync();
                return targetHotelProduct;
            }
            throw new Exception("Beklenmeyen hata!");
        }
        public async Task AddItemToHotelProductAsync(VM_Create_HotelProductItem hotelProductItem)
        {
            HotelProduct? hotelProduct = await ContextUser();
            if (hotelProduct != null)
            {
                HotelProductItem _hotelProductItem = await _hotelProductItemReadRepository.GetSingleAsync(hi => hi.HotelProductId == hotelProduct.Id && hi.ProductId == Guid.Parse(hotelProductItem.ProductId));
                if (_hotelProductItem != null)
                    _hotelProductItem.Quantity++;
                else
                    await _hotelProductItemWriteRepository.AddAsync(new()
                    {
                        HotelProductId = hotelProduct.Id,
                        ProductId = Guid.Parse(hotelProductItem.ProductId),
                        Quantity = hotelProductItem.Quantity,
                    });
                await _hotelProductWriteRepository.SaveAsync();
            }
        }

        public async Task<List<HotelProductItem>> GetHotelProductItemsAsync()
        {
            HotelProduct? hotelProduct = await ContextUser();
            HotelProduct? result = await _hotelProductReadRepository.Table.Include(h => h.HotelProductItems).ThenInclude(hi => hi.Product).FirstOrDefaultAsync(h => h.Id == hotelProduct.Id);
            return result.HotelProductItems.ToList();
        }

        public async Task RemoveHotelProductItemAsync(string hotelProductItemId)
        {
            HotelProductItem? hotelProductItem = await _hotelProductItemReadRepository.GetByIdAsync(hotelProductItemId);
            if (hotelProductItem != null)
            {
                _hotelProductItemWriteRepository.Remove(hotelProductItem);
                await _hotelProductWriteRepository.SaveAsync();
            }
        }

        public async Task UpdateQuantityAsync(VM_Update_HotelProductItem hotelProductItem)
        {
            HotelProductItem? _hotelProductItem = await _hotelProductItemReadRepository.GetByIdAsync(hotelProductItem.HotelProductId);

            if (_hotelProductItem == null)
            {
                _hotelProductItem.Quantity = hotelProductItem.Quantity;
                await _hotelProductItemWriteRepository.SaveAsync();
            }
        }
    }
}
