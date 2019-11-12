using System;
using WTW_IOC.Logic.Data;

namespace WTW_IOC.Logic.Logic
{
    public class SampleLogic : ISampleLogic
    {
        private ISampleData _sampleData;
        private ICalculator _calculator;

        public Guid InstanceId { get; }

        public SampleLogic(ICalculator calculator, ISampleData sampleData)
        {
            InstanceId = Guid.NewGuid();
            _calculator = calculator;
            _sampleData = sampleData;
        }

        public string[] LoadSampleModel()
        {
            return _sampleData.LoadData();
        }

        public string AddMessage(int first, int second)
        {
            int added = _calculator.Add(first, second);
            return $"{first} + {second} = {added}";
        }

        public string SubtractMessage(int first, int second)
        {
            int subtracted = _calculator.Subtract(first, second);
            return $"{first} - {second} = {subtracted}";
        }

        public string MultiplyMessage(int first, int second)
        {
            int multiplied = _calculator.Multiply(first, second);
            return $"{first} x {second} = {multiplied}";
        }

        public string DivideMessage(int first, int second)
        {
            double divided = _calculator.Divide(first, second);
            return $"{first} % {second} = {divided}";
        }


    }
}
