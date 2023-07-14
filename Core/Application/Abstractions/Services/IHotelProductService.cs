using Application.ViewModels.HotelProducts;
using Domain.Entities;
namespace Application.Abstractions.Services
{
    public interface IHotelProductService
    {
        public Task<List<HotelProductItem>> GetHotelProductItemsAsync();
        public Task AddItemToHotelProductAsync(VM_Create_HotelProductItem hotelProductItem);
        public Task UpdateQuantityAsync(VM_Update_HotelProductItem hotelProductItem);
        public Task RemoveHotelProductItemAsync(string hotelProductItemId);
    }
}
