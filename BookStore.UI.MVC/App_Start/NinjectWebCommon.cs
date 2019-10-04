[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BookStore.UI.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BookStore.UI.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace BookStore.UI.MVC.App_Start
{
    using System;
    using System.Web;
    using BookStore.BLL.Abstract;
    using BookStore.BLL.Concrete;
    using BookStore.BLL.IOC.Ninject;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAddressService>().To<AddressService>();
            kernel.Bind<IAuthorService>().To<AuthorService>();
            kernel.Bind<IBookService>().To<BookService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ICityService>().To<CityService>();
            kernel.Bind<ICountryService>().To<CountryService>();
            kernel.Bind<IDistrictService>().To<DistrictService>();
            kernel.Bind<ILanguageService>().To<LanguageService>();
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<IPublishingHouseService>().To<PublishingHouseService>();
            kernel.Bind<IMessageService>().To<MessageService>();
            kernel.Bind<ISubCategoryService>().To<SubCategoryService>();
            kernel.Bind<ICampaignService>().To<CampaignService>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRoleService>().To<UserRoleService>();
            kernel.Load<DalModule>();
        }        
    }
}
