using System;
using System.Collections.Generic;
using System.Reflection;

namespace WTW_IOC.IOC.Resolvers
{
    public class TransientResolver : IResolver
    {
        private readonly Dictionary<Type, object> values = new Dictionary<Type, object>();

        public object Resolve(Type contractType, Type implType)
        {
            if (!values.ContainsKey(contractType))
                values[contractType] = Activator.CreateInstance(implType);

            return values[contractType];
        }

        public object Resolve(Type contractType, ConstructorInfo constructor, object[] dependencies)
        {
            if (!values.ContainsKey(contractType))
                values[contractType] = constructor.Invoke(dependencies);

            return values[contractType];
        }

    }
}
