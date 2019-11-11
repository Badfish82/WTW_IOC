using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTW_IOC.Common.Data;

namespace WTW_IOC.Common.Logic
{
    public class SampleLogic : ISampleLogic
    {
        private ISampleData _sampleData;

        public SampleLogic(ISampleData sampleData)
        {
            _sampleData = sampleData;
        }

        public string[] LoadSampleModel()
        {
            return _sampleData.LoadData();
        }
    }
}
