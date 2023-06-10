using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HotelAPIDbContext>
    {

        // package manager console'dan değil de powershell'den yapılacak migration işlemleri için bu class kullanılır
        public HotelAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<HotelAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new HotelAPIDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
