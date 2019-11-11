using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WTW_IOC.Common
{
    public class WTWIOC
    {
        private static Dictionary<Type, Type> types = new Dictionary<Type, Type>();

        public static void Register<TContract, TImpl>()
        {
            types[typeof(TContract)] = typeof(TImpl);
        }

        public static void RegisterType<TContract>(Type type)
        {
            types[typeof(TContract)] = type;
        }

        public static T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public static Object Resolve(Type contract)
        {
            Type impl = types[contract];
            var constructor = impl.GetConstructors()[0];
            var paramInfos = constructor.GetParameters();
            if (!paramInfos.Any())
                return Activator.CreateInstance(impl);

            var parameters = paramInfos.Select(pi => Resolve(pi.ParameterType)).ToArray();
            return constructor.Invoke(parameters);
        }
    }
}
