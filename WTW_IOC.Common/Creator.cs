using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTW_IOC.Common.Resolvers;

namespace WTW_IOC.Common
{
    public class Creator
    {
        public Type Type { get; set; }
        public IResolver Resolver { get; set; }
    }
}
