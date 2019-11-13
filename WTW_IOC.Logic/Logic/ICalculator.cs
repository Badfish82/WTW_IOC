using System;

namespace WTW_IOC.Logic
{
    public interface ICalculator : IInstance
    {
        int Add(int first, int second);
        int Subtract(int first, int second);
        int Multiply(int first, int second);
        double Divide(int first, int second);
    }
}
