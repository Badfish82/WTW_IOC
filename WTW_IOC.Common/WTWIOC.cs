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
        private TransientResolver _transientResolver;

        private static readonly Dictionary<Type, Creator> types = new Dictionary<Type, Creator>();  // Make static if we want to cross container boundaries

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WTWIOC()
        {
            _transientResolver = new TransientResolver();
        }

        /// <summary>
        /// Construct IOC Container with singleton instance
        /// </summary>
        private WTWIOC(SingletonResolver singletonResolver)
            : this()
        {
            _singletonResolver = singletonResolver;
        }

        /// <summary>
        /// Add a sub-contrainer for the current container
        /// </summary>
        /// <returns></returns>
        public WTWIOC AddContainer()
        {
            return new WTWIOC(_singletonResolver);
        }

        /// <summary>
        /// Register a contract and implementation types
        /// </summary>
        /// <param name="scope">Lifetime Scope (Singleton, Transient, PerInstance)</param>
        public void Register<TContract, TImpl>(LifetimeScopeType scope = LifetimeScopeType.Transient)
        {
            RegisterType<TContract>(typeof(TImpl), scope);
        }


        /// <summary>
        /// Register a contract and implementation types
        /// </summary>
        /// <param name="implType">Implementation Type</param>
        /// <param name="scope">Lifetime Scope (Singleton, Transient, PerInstance)</param>
        public void RegisterType<TContract>(Type implType, LifetimeScopeType scope = LifetimeScopeType.Transient)
        {
            IResolver resolver = GetResolver(scope);
            types[typeof(TContract)] = new Creator { Type = implType, Resolver = resolver };
        }

        /// <summary>
        /// Resolve the implementation of the registered contract
        /// </summary>
        /// <typeparam name="T">Implementation of the contract</typeparam>
        /// <returns>Implementation value</returns>
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        /// <summary>
        /// Resolve the implementation of the registered contract
        /// </summary>
        /// <param name="contract">Register contract type</param>
        /// <returns>Implementation value (must be cast to implementation type)</returns>
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
            return creator.Resolver.Resolve(contract, constructor, dependencies);
        }

        public IEnumerable<object> ResolveAll(Type contract)
        {
            if (!types.ContainsKey(contract))
                throw new Exception($"Unable to resolve type contract: {contract.Name}. Please register the contract prior to resolving.");

            Creator creator = types[contract];
            ConstructorInfo constructor = creator.Type.GetConstructors()[0];
            ParameterInfo[] paramInfos = constructor.GetParameters();
            if (!paramInfos.Any())
                return new List<object> { creator.Resolver.Resolve(contract, creator.Type) };

            var dependencies = paramInfos.Select(pi => Resolve(pi.ParameterType)).ToList();
            dependencies.Add(constructor.Invoke(dependencies.ToArray()));
            return dependencies;
        }

        public void Dispose()
        {
            _transientResolver = null;
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
