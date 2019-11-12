using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTW_IOC.Common.Resolvers;

namespace WTW_IOC.Common
{
    //public class LifetimeScope : IDisposable
    //{
    //    public LifetimeScopeType ScopeType { get; set; }
    //    public IResolver Resolver { get; set; }
        

    //    public LifetimeScope(LifetimeScopeType scopeType)
    //    {
    //        ScopeType = scopeType;
    //    }

    //    public void BeginLifetimeScope()
    //    {
    //        Resolver = new TransientResolver();
    //    }

    //    public void Dispose()
    //    {
    //        //Resolver.Clear();
    //    }
        
    //}

    public enum LifetimeScopeType
    {
        PerInstance,
        Singleton,
        Transient
    }
}
