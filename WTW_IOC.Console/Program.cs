using System;
using WTW_IOC.Common;
using WTW_IOC.Common.Data;
using WTW_IOC.Common.Logic;

namespace WTW_IOC.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var container = new WTWIOC())
            {
                container.Register<ISampleData, SampleData>(LifetimeScopeType.Singleton);
                container.Register<ISampleLogic, SampleLogic>(LifetimeScopeType.Singleton);
                container.Register<ICalculator, Calculator>(LifetimeScopeType.Singleton);
                using (var container2 = container.AddContainer())
                {                    
                    var test = container2.Resolve<ISampleLogic>();
                    var model = test.LoadSampleModel();
                    Console.WriteLine(test.AddMessage(4, 6));
                    Console.WriteLine(test.SubtractMessage(100239, 83837));
                    Console.WriteLine(test.MultiplyMessage(1000, 100));
                    Console.WriteLine(test.DivideMessage(1000000, 100));
                }
                    
            }     
        }
    }
}
