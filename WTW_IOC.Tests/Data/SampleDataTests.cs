using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTW_IOC.Logic.Data;
using Xunit;

namespace WTW_IOC.Tests.Data
{
    public class SampleDataTests
    {
        private SampleData _sampleData;

        public SampleDataTests()
        {
            _sampleData = new SampleData();
        }

        [Fact]
        public void SampleData_Load()
        {
            var result = _sampleData.LoadData();

            Assert.NotNull(result);
            Assert.True(result.Length == 6);
        }
    }
}
