using System;

namespace WTW_IOC.Common.Resolvers
{
    public class InstanceResolver : IResolver
    {
        public object Resolve(Type contractType, Type implType)
        {
            return Activator.CreateInstance(implType);
        }
    }
}
