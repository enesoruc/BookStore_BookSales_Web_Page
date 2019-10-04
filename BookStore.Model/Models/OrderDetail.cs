using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    public class OrderDetail
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //ForeignKey
        public int OrderID { get; set; }
        public int BookID { get; set; }

        //Nav Props
        public virtual Order Order { get; set; }
        public virtual Book Book { get; set; }
    }
}
