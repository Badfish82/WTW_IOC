using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WTW_IOC.Common.Resolvers;

namespace WTW_IOC.Common
{
    public class WTWIOC : IDisposable
    {
        private readonly SingletonResolver _singletonResolver = new SingletonResolver();
        private readonly TransientResolver _transientResolver;

        private readonly Dictionary<Type, Creator> types = new Dictionary<Type, Creator>();

        public WTWIOC()
        {
            _transientResolver = new TransientResolver();
        }

        private WTWIOC(SingletonResolver singletonResolver)
            : this()
        {
            _singletonResolver = singletonResolver;
        }

        public WTWIOC AddContainer()
        {
            return new WTWIOC(_singletonResolver);
        }

        public void Register<TContract, TImpl>(LifetimeScopeType scope = LifetimeScopeType.Transient)
        {
            RegisterType<TContract>(typeof(TImpl), scope);
        }

        public void RegisterType<TContract>(Type type, LifetimeScopeType scope = LifetimeScopeType.Transient)
        {
            IResolver resolver = GetResolver(scope);
            types[typeof(TContract)] = new Creator { Type = type, Resolver = resolver };
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type contract)
        {
            if (!types.ContainsKey(contract))
                throw new Exception($"Unable to resolve type contract: {contract.Name}. Please register the contract prior to resolving.");

            Creator creator = types[contract];
            ConstructorInfo constructor = creator.Type.GetConstructors()[0];
            ParameterInfo[] paramInfos = constructor.GetParameters();
            if (!paramInfos.Any())
                return creator.Resolver.Resolve(contract, creator.Type);

            var dependencies = paramInfos.Select(pi => Resolve(pi.ParameterType)).ToArray();
            return constructor.Invoke(dependencies);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private IResolver GetResolver(LifetimeScopeType scopeType = LifetimeScopeType.Transient)
        {
            switch (scopeType)
            {                
                case LifetimeScopeType.PerInstance:
                    return new InstanceResolver();
                case LifetimeScopeType.Singleton:
                    return _singletonResolver;
                case LifetimeScopeType.Transient:
                default:
                    return _transientResolver;
            }   
        }
    }
}
