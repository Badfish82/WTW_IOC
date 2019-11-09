using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTW_IOC.Common
{
    public interface IIoc
    {
        void Register<T>(T val);
        void RegisterType(Type type);
        T Resolve<T>();
    }
}
