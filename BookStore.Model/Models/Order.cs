using BookStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int TotalPrice { get; set; }
        public string ShippedDate { get; set; }
        public string OrderDate { get; set; }

        //Foreign Key
        public int UserID { get; set; }
        public int AddressID { get; set; }

        //Nav Props
        public virtual User User { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
