using BookStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    public class Category:BaseEntity
    {
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
            Campaigns = new HashSet<Campaign>();
        }
        public string Name { get; set; }
        public string Description { get; set; }


        public virtual ICollection<SubCategory> SubCategories { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}
