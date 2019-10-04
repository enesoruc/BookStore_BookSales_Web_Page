using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Concrete.EntityFramework.Mappings
{
    public class CampaignMapping : EntityTypeConfiguration<Campaign>
    {
        public CampaignMapping()
        {
            Property(a => a.Name).HasMaxLength(100);

            //HasMany(a => a.Categories)
            //    .WithMany(a => a.Campaigns)
            //    .Map(a=> {
            //        a.MapLeftKey("CategoryID");
            //        a.MapRightKey("CampaignID");
            //        a.ToTable("CategoryCampaign");
            //    });
        }
    }
}
