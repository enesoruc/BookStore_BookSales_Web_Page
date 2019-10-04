using BookStore.DAL.Abstract;
using BookStore.DAL.Concrete.EntityFramework.DAL;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.IOC.Ninject
{
    public class DalModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAddressDAL>().To<EFAddressDAL>();
            Bind<IAuthorDAL>().To<EFAuthorDAL>();
            Bind<IBookDAL>().To<EFBookDAL>();
            Bind<ICategoryDAL>().To<EFCategoryDAL>();
            Bind<ICityDAL>().To<EFCityDAL>();
            Bind<ICountryDAL>().To<EFCountryDAL>();
            Bind<IDistrictDAL>().To<EFDistrictDAL>();
            Bind<ILanguageDAL>().To<EFLanguageDAL>();
            Bind<IOrderDAL>().To<EFOrderDAL>();
            Bind<IPublishingHouseDAL>().To<EFPublishingHouseDAL>();
            Bind<IUserDAL>().To<EFUserDAL>();
            Bind<IUserRoleDAL>().To<EFUserRoleDAL>();
            Bind<IMessageDAL>().To<EFMessageDAL>();
            Bind<ISubCategoryDAL>().To<EFSubCategoryDAL>();
            Bind<ICampaignDAL>().To<EFCampaignDAL>();
            Bind<ICommentDAL>().To<EFCommentDAL>();
        }
    }
}
