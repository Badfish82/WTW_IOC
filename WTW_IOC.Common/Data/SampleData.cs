using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTW_IOC.Common.Data
{
    public class SampleData : ISampleData
    {
        public string[] LoadData()
        {
            return new string[]
            {
                "Test1",
                "Test2",
                "Test3",
                "Test4",
                "Test5",
                "Test6"
            };
        }
    }
}
