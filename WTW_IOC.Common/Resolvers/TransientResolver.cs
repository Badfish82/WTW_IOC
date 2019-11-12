using System;
using System.Collections.Generic;

namespace WTW_IOC.Common.Resolvers
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

        //public void Clear()
        //{
        //    Values = null;
        //}

    }
}
