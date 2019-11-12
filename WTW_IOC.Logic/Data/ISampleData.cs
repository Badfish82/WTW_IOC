using System;

namespace WTW_IOC.Logic.Data
{
    public interface ISampleData : IInstance
    {
        string[] LoadData();
    }
}
