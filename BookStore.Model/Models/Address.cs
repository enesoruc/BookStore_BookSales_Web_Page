using BookStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    public class Address:BaseEntity
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }
        public string Name { get; set; }
        public string AddressDetail { get; set; }

        //Foreign Key
        public int UserID { get; set; }
        public int DistrictID { get; set; }

        //Nav Props
        public virtual User User { get; set; }
        public virtual District District { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
