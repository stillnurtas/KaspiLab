using AdventureWorks.BL.Interfaces;
using AdventureWorks.EF.Contexts;
using AdventureWorks.Repository.Interfaces;
using AdventureWorks.Repository.UnitOfWork;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.Caching.Memory;
using AdventureWorks.Auth.Identity;
using AdventureWorks.Auth.IdentityManagers;
using Microsoft.Owin.Security;

namespace AdventureWorks.Web.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            #region RegisterTypes

            //builder.RegisterType<ProductService>().As<IProductService>();
            //builder.RegisterType<AWUnitOfWork>().As<IUnitOfWork>()
            //                                    .WithParameter("context", new AWContext());
            //builder.RegisterType<CacheManager>().As<ICacheManager>()
            //                                    .WithParameter("cache", new MemoryCache(new MemoryCacheOptions()))
            //                                    .SingleInstance();
            //builder.RegisterType<AuthService>().As<IAuthService>().InstancePerRequest();
            //builder.RegisterType<IAuthService>().AsSelf().InstancePerRequest();
            //builder.RegisterType<AppUserManager>().AsSelf().InstancePerRequest();
            builder.Register(r => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();

            #endregion

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}