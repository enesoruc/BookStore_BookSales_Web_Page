using BookStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    public class Campaign : BaseEntity
    {
        public string Name { get; set; }
        public int DiscountAmount { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }

        //ForeignKey
        public int CategoryID { get; set; }
        //NavProps
        public Category Category { get; set; }
        //public virtual ICollection<Category> Categories { get; set; }
    }
}
