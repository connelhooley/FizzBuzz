using System;
using FizzBuzz.Domain.Concrete;
using FluentAssertions;
using Xunit;
// ReSharper disable ObjectCreationAsStatement

namespace FizzBuzz.Domain.UnitTests.SettingsStoreTests
{
    public class Constructor : TestBase
    {
        [Fact]
        public void SettingsStore_ConstructorWithNullNowGetter_ThrowsArgumentNullException()
        {
            //act
            Action act = () => new SettingsStore(null);

            //assert
            act.ShouldThrow<ArgumentNullException>().Which.ParamName.Should().Be("nowGetter");
        }

        [Fact]
        public void SettingsStore_ConstructorWithValidParameters_DoesNotThrow()
        {
            //act
            Action act = () => new SettingsStore(NowGetterMock.Object);
            
            //assert
            act.ShouldNotThrow();
        }
    }
}