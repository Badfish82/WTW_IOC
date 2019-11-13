using System;
using System.Web.Http;
using System.Web.Mvc;
using WTW_IOC.IOC;
using WTW_IOC.Logic.Data;
using WTW_IOC.Logic;
using WTW_IOC.Web.Controllers;
using WTW_IOC.Web.IOC;

namespace WTW_IOC.Web
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            var container = BuildContainer();

            DependencyResolver.SetResolver(new WTWIOC_MvcDependencyResolver(container));
            ControllerBuilder.Current.SetControllerFactory(new WTWIOCControllerFactory(container));
            GlobalConfiguration.Configuration.DependencyResolver = new WTWIOC_ApiDependencyResolver(container);
        }

        private static WTWIOC BuildContainer()
        {
            var container = new WTWIOC();

            container.Register<HomeController, HomeController>(LifetimeScopeType.PerInstance);
            container.Register<ValuesController, ValuesController>(LifetimeScopeType.PerInstance);

            container.Register<ISampleData, SampleData>(LifetimeScopeType.Singleton);
            container.Register<ISampleLogic, SampleLogic>(LifetimeScopeType.Singleton);
            container.Register<ICalculator, Calculator>(LifetimeScopeType.Singleton);

            return container;
        }
    }
}