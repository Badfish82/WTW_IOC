using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTW_IOC.Common.Data;

namespace WTW_IOC.Common.Logic
{
    public class Calculator : ICalculator
    {
        private ISampleData _sampleData;

        public Calculator(ISampleData sampleData)
        {
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
