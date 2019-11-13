using System;
using WTW_IOC.Logic.Data;

namespace WTW_IOC.Logic
{
    public class Calculator : ICalculator
    {
        private ISampleData _sampleData;

        public Guid InstanceId { get; }

        public Calculator(ISampleData sampleData)
        {
            InstanceId = Guid.NewGuid();
            _sampleData = sampleData;
        }

        public int Add(int first, int second)
        {
            return first + second;
        }

        public int Subtract(int first, int second)
        {
            return first - second;
        }       

        public int Multiply(int first, int second)
        {
            return first * second;
        }

        public double Divide(int first, int second)
        {
            return first / second;
        }
    }
}
