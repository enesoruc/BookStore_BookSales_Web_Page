using BookStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    public class District:BaseEntity
    {
        public District()
        {
            Addresses = new HashSet<Address>();
        }
        public string Name { get; set; }

        //Foreign Key
        public int CityID { get; set; }

        //Nav Props
        public virtual City City { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
