using FizzBuzz.Domain.Abstract;
using FizzBuzz.Domain.Concrete;
using FluentAssertions.Autofac;
using Xunit;

namespace FizzBuzz.WebUi.UnitTests.IocTests
{
    public class DependancyBindings
    {
        [Fact]
        public void Ioc_FizzBuzzGeneratorIsRegistered_AsIFizzBuzzGenerator() =>
            IocConfig.Container.Should()
                .Resolve<IFizzBuzzGenerator>()
                .As<FizzBuzzGenerator>();
        
        [Fact]
        public void Ioc_NowGetterIsRegistered_AsINowGetter() =>
            IocConfig.Container.Should()
                .Resolve<INowGetter>()
                .As<NowGetter>();
        
        [Fact]
        public void Ioc_SettingsStoreIsRegistered_AsISettingsStore() =>
            IocConfig.Container.Should()
                .Resolve<ISettingsStore>()
                .As<SettingsStore>();

        [Fact]
        public void Ioc_PagerIsRegistered_AsIPager() =>
            IocConfig.Container.Should()
                .Resolve<IPager>()
                .As<Pager>();

        [Fact]
        public void Ioc_StubUserInputLoggerIsRegistered_AsIUserInputLogger() =>
            IocConfig.Container.Should()
                .Resolve<IUserInputLogger>()
                .As<StubUserInputLogger>();
    }
}