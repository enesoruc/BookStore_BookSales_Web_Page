
using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Concrete.EntityFramework.Mappings
{
    public class AddressMapping :EntityTypeConfiguration<Address>
    {
        public AddressMapping()
        {
            Property(a => a.Name).HasMaxLength(50);
            Property(a => a.AddressDetail).HasMaxLength(255);
        }
    }
}
