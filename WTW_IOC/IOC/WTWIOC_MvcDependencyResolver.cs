using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WTW_IOC.Common;

namespace WTW_IOC.Web.IOC
{
    public class WTWIOC_MvcDependencyResolver : IDependencyResolver
    {
        private WTWIOC _container;

        public WTWIOC_MvcDependencyResolver(WTWIOC container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch
            {
                return Enumerable.Empty<object>();
            }
        }
    }
}
