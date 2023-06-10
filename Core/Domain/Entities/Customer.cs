using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }

        // bir customer'ın birden fazla room'ı olabilir
        // ama bir room'ın birden fazla customer'ı olamaz
        public ICollection<Room> Rooms { get; set; }
    }
}
