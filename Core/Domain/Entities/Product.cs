using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }

        // product ve room arasında çok'a çok ilişki olduğunu ifade etmek için product classına da room'ı koyarız
        // her product'ın birden fazla room olduğu ifade edilir
        public ICollection<Room> Rooms { get; set; }
    }
}
