using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTW_IOC.Common;
using WTW_IOC.Common.Data;
using WTW_IOC.Common.Logic;

namespace WTW_IOC.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WTWIOC.Register<ISampleData, SampleData>();
            WTWIOC.Register<ISampleLogic, SampleLogic>();

            var test = WTWIOC.Resolve<ISampleLogic>();
            var model = test.LoadSampleModel();
        }
    }
}
