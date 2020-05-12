using FizzBuzz.WebUi.Controllers;
using FluentAssertions.Autofac;
using Xunit;

namespace FizzBuzz.WebUi.UnitTests.IocTests
{
    public class ControllerBindings
    {
        [Fact]
        public void Ioc_FizzBuzzControllerIsRegistered_AsSelf() =>
            IocConfig.Container.Should()
                .Resolve<FizzBuzzController>()
                .AsSelf();
    }
}