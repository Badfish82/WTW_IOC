using System;
using System.Reflection;

namespace WTW_IOC.IOC.Resolvers
{
    public interface IResolver
    {
        Object Resolve(Type contractType, Type implType);
        Object Resolve(Type contractType, ConstructorInfo constructor, object[] dependencies);
    }
}
