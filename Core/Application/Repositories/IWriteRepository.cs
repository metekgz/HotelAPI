using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        // bool eklememin nedeni işlem yapıldığında true veya false dönmek için
        // gelen entity ne ise ekler
        Task<bool> AddAsync(T entity);
        // birden fazla ekler
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T entity);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(string id);
        bool Update(T entity);
        Task<int> SaveAsync();

    }
}
