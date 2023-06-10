using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        // IRepository IWrite ve IRead'ın genel basesidir
        DbSet<T> Table { get; }
    }
}
