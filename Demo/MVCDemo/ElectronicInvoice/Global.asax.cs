﻿using System.Reflection;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ElectronicInvoice.IOC;

namespace ElectronicInvoice
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //使用AutoFac
            var builder = AutofacConfig.Register();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            AutofacDependencyResolver resolver = new AutofacDependencyResolver(builder.Build());
            DependencyResolver.SetResolver(resolver);
        }
    }
}