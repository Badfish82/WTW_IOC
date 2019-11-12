using System;
using System.Web.Mvc;
using System.Web.Routing;
using WTW_IOC.Common;

namespace WTW_IOC.Web.IOC
{
    public class WTWIOCControllerFactory : DefaultControllerFactory
    {
        private WTWIOC _container;

        public WTWIOCControllerFactory(WTWIOC container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)_container.Resolve(controllerType);
        }
    }
}