using System;

namespace WTW_IOC.Logic.Logic
{
    public interface ISampleLogic: IInstance
    {
        string[] LoadSampleModel();
        string AddMessage(int first, int second);
        string SubtractMessage(int first, int second);
        string MultiplyMessage(int first, int second);
        string DivideMessage(int first, int second);
    }
}
