using BookStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    public class City:BaseEntity
    {
        public City()
        {
            Districts = new HashSet<District>();
        }
        public string Name { get; set; }

        //Foreign Key
        public int CountryID { get; set; }

        //Nav Props
        public virtual Country Country { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
