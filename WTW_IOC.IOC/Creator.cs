using System;
using WTW_IOC.IOC.Resolvers;

namespace WTW_IOC.IOC
{
    public class Creator
    {
        public Type Type { get; set; }
        public IResolver Resolver { get; set; }
    }
}
