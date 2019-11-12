using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
