using System;
using System.Collections.Generic;

namespace WTW_IOC.IOC
{
    public interface IIoc : IDisposable
    {
        WTWIOC AddContainer();
        void Register<TContract, TImpl>(LifetimeScopeType scope);
        void RegisterType<TContract>(Type implType, LifetimeScopeType scope);
        T Resolve<T>();
        object Resolve(Type contract);
        IEnumerable<object> ResolveAll(Type contract);
    }
}
