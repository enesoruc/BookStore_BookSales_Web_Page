using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Concrete.EntityFramework.Mappings
{
    public class PublishingHouseMapping : EntityTypeConfiguration<PublishingHouse>
    {
        public PublishingHouseMapping()
        {
            Property(a => a.CompanyName).HasMaxLength(50);
            Property(a => a.ContactName).HasMaxLength(50);
            Property(a => a.Phone).IsRequired().HasColumnType("char").HasMaxLength(12);
            Property(a => a.AddressDetail).HasMaxLength(1000);
        }
    }
}
