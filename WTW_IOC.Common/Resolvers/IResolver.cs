using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTW_IOC.Common.Resolvers
{
    public interface IResolver
    {
        Object Resolve(Type contractType, Type implType);
    }
}
