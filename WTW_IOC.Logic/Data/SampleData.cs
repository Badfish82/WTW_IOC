using System;

namespace WTW_IOC.Logic.Data
{
    public class SampleData : ISampleData
    {
        public Guid InstanceId { get; }

        public SampleData()
        {
            InstanceId = Guid.NewGuid();
        }

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
