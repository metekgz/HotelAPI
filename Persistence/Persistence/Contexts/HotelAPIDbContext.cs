﻿using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class HotelAPIDbContext : DbContext
    {
        public HotelAPIDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }

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
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
