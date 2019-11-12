using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTW_IOC.Common;
using WTW_IOC.Logic.Data;
using WTW_IOC.Logic.Logic;
using Xunit;

namespace WTW_IOC.Tests.IOC
{
    public class WTWIOCTests
    {

        [Fact]
        public void WTWIOC_LoadSampleModel()
        {
            var container = new WTWIOC();
            container.Register<ISampleData, SampleData>();
            container.Register<ISampleLogic, SampleLogic>();
            container.Register<ICalculator, Calculator>();

            var sampleLogic = container.Resolve<ISampleLogic>();

            var model = sampleLogic.LoadSampleModel();

            Assert.NotNull(model);
        }

        [Fact]
        public void WTWIOC_AddMessage()
        {
            var container = new WTWIOC();
            container.Register<ISampleData, SampleData>();
            container.Register<ISampleLogic, SampleLogic>();
            container.Register<ICalculator, Calculator>();

            var sampleLogic = container.Resolve<ISampleLogic>();

            string message = sampleLogic.AddMessage(4, 6);

            Assert.NotNull(message);

            //Console.WriteLine(test.SubtractMessage(100239, 83837));
            //Console.WriteLine(test.MultiplyMessage(1000, 100));
            //Console.WriteLine(test.DivideMessage(1000000, 100));
        }

        [Fact]
        public void WTWIOC_PerInstance()
        {
            var container = new WTWIOC();
            container.Register<ISampleLogic, SampleLogic>(LifetimeScopeType.PerInstance);
            container.Register<ISampleData, SampleData>(LifetimeScopeType.PerInstance);
            container.Register<ICalculator, Calculator>(LifetimeScopeType.PerInstance);

            var sampleLogic = container.Resolve<ISampleLogic>();
            var sampleLogic2 = container.Resolve<ISampleLogic>();

            Assert.NotNull(sampleLogic);
            Assert.NotNull(sampleLogic2);
            Assert.NotEqual(sampleLogic.InstanceId, sampleLogic2.InstanceId);
        }

        [Fact]
        public void WTWIOC_Singleton()
        {
            var container = new WTWIOC();
            container.Register<ISampleLogic, SampleLogic>(LifetimeScopeType.Singleton);
            container.Register<ISampleData, SampleData>(LifetimeScopeType.Singleton);
            container.Register<ICalculator, Calculator>(LifetimeScopeType.Singleton);

            var sampleLogic = container.Resolve<ISampleLogic>();
            var sampleLogic2 = container.Resolve<ISampleLogic>();

            Assert.NotNull(sampleLogic);
            Assert.NotNull(sampleLogic2);
            Assert.Equal(sampleLogic.InstanceId, sampleLogic2.InstanceId);
        }

        [Fact]
        public void WTWIOC_Transient()
        {
            var container = new WTWIOC();
            container.Register<ISampleLogic, SampleLogic>(LifetimeScopeType.Transient);
            container.Register<ISampleData, SampleData>(LifetimeScopeType.Transient);
            container.Register<ICalculator, Calculator>(LifetimeScopeType.Transient);

            var sampleLogic = container.Resolve<ISampleLogic>();
            var sampleLogic2 = container.Resolve<ISampleLogic>();

            Assert.NotNull(sampleLogic);
            Assert.NotNull(sampleLogic2);
            Assert.Equal(sampleLogic.InstanceId, sampleLogic2.InstanceId);
        }

        [Fact]
        public void WTWIOC_ResolveException()
        {            
            Assert.Throws<Exception>(() =>
            {
                var container = new WTWIOC();

                var sampleLogic = container.Resolve<ISampleLogic>();
            });
        }
    }
}
