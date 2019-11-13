using System;
using System.Reflection;

namespace WTW_IOC.IOC.Resolvers
{
    public class InstanceResolver : IResolver
    {
        public object Resolve(Type contractType, Type implType)
        {
            return Activator.CreateInstance(implType);
        }

        public object Resolve(Type contractType, ConstructorInfo constructor, object[] dependencies)
        {
            return constructor.Invoke(dependencies);
        }
    }
}
