using GMAO.App.AutoMapper;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GMAO.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            IUnityContainer container = new UnityContainer();
            GMAO.Ioc.IoC i = new GMAO.Ioc.IoC(container);
            i.ResgitreType();
            DependencyResolver.SetResolver(new GMAO.Ioc.UnityDependencyResolver(container));

            //AutoMapper
            AutoMapperWebConfiguration.Configure();
        }
        }
    }

