using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using WTW_IOC.Common;

namespace WTW_IOC.Web.IOC
{
    public class WTWIOC_ApiDependencyResolver : IDependencyResolver
    {
        private WTWIOC _container;

        public WTWIOC_ApiDependencyResolver(WTWIOC container)
        {
            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            var newContainer = _container.AddContainer();
            return new WTWIOC_ApiDependencyResolver(newContainer);
        }

        public void Dispose()
        {
            _container.Dispose();
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