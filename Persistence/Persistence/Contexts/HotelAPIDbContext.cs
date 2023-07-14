using Domain.Entities;
using Domain.Entities.Common;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public class HotelAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public HotelAPIDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }
        public DbSet<HotelProduct> HotelProducts { get; set; }
        public DbSet<HotelProductItem> HotelProductItems { get; set; }

        // rooom ile hotelProduct'ın bire bir ilişkili olduğunu tabloya aktarmak için:
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // id nin primary key olduğunu belirtmek için
            builder.Entity<Room>().HasKey(p => p.Id);
            // bire bir iliişki ile bağlamak için
            builder.Entity<HotelProduct>().HasOne(p => p.Room).WithOne(r => r.HotelProduct).HasForeignKey<Room>(p => p.Id);

            // normal dbcontext değil de IdentityDbContext kullandığım için OnModelCreating override ettiğim için en son bu kodu yazmam gerekiyor
            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            // ChangeTracker = Entityler üzerinde yapılan değişikliklerin ya da yeni eklenen verilerin yakalanmasını
            // sağlayan property'dir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar

            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                // herhangi bir atama işlemi yapılmasına gerek olmadığı için
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    // ikisi de değilse bunu döndürsün silinen veri için 
                    _ => DateTime.UtcNow,
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
