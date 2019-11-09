using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTW_IOC.Common
{
    public class WTWIOC : IIoc
    {
        public void Register<T>(T val)
        {
            throw new NotImplementedException();
        }

        public void RegisterType(Type type)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }
    }
}
