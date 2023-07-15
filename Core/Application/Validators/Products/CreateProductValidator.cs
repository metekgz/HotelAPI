using Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_HotelRooms>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Lütfen ürün adını yazınız").MaximumLength(50).WithMessage("Ürün adı 50 karakterden fazla olamaz lütfen tekrar deneyin");

            RuleFor(p => p.Stock).NotEmpty().NotNull().WithMessage("Lütfen stok miktarını yazınız").Must(s => s >= 0).WithMessage("Stok bilgisi 0 veya daha fazla olmalıdır");

            RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("Lütfen fiyat yazınız").Must(s => s >= 0).WithMessage("Fiyat bilgisi 0 veya daha fazla olmalıdır");
        }
    }
}
