using System;
using WTW_IOC.IOC;
using WTW_IOC.Logic.Data;
using WTW_IOC.Logic;
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
            Assert.Equal(6, model.Length);
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
            Assert.Equal("4 + 6 = 10", message);
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
        public void WTWIOC_MultipleTransient()
        {
            var container = new WTWIOC();
            container.Register<ISampleData, SampleData>(LifetimeScopeType.Transient);
            var container2 = container.AddContainer();

            var sampleData = container.Resolve<ISampleData>();
            var sampleData2 = container2.Resolve<ISampleData>();

            Assert.NotNull(sampleData);
            Assert.NotNull(sampleData);
            Assert.NotEqual(sampleData.InstanceId, sampleData2.InstanceId);
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
