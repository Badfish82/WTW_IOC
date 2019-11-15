using System;

namespace WTW_IOC.IOC
{
    public class Creator
    {
        public Type Type { get; set; }
        public LifetimeScopeType Scope { get; set; }
    }
}
