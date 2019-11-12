using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTW_IOC.Logic.Data
{
    public interface ISampleData : IInstance
    {
        string[] LoadData();
    }
}
