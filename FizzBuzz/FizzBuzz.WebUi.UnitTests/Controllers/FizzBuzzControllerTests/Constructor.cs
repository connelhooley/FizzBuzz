using System;
using FizzBuzz.WebUi.Controllers;
using FluentAssertions;
using Xunit;
// ReSharper disable ObjectCreationAsStatement

namespace FizzBuzz.WebUi.UnitTests.Controllers.FizzBuzzControllerTests
{
    public class Constructor : TestBase
    {
        [Fact]
        public void FizzBuzzController_ConstructorWithNullFizzBuzzGenerator_ThrowsArgumentNullException()
        {
            //act
            Action act = () => new FizzBuzzController(
                null, 
                SettingsStoreMock.Object, 
                PagerMock.Object,
                UserInputLoggerMock.Object);

            //assert
            act
                .ShouldThrow<ArgumentNullException>()
                .Which.ParamName.Should().Be("fizzBuzzGenerator");
        }

        [Fact]
        public void FizzBuzzController_ConstructorWithNullSettingsStore_ThrowsArgumentNullException()
        {
            //act
            Action act = () => new FizzBuzzController(
                FizzBuzzGeneratorMock.Object, 
                null, 
                PagerMock.Object,
                UserInputLoggerMock.Object);

            //assert
            act
                .ShouldThrow<ArgumentNullException>()
                .Which.ParamName.Should().Be("settingsStore");
        }

        [Fact]
        public void FizzBuzzController_ConstructorWithNullPager_ThrowsArgumentNullException()
        {
            //act
            Action act = () => new FizzBuzzController(
                FizzBuzzGeneratorMock.Object, 
                SettingsStoreMock.Object, 
                null,
                UserInputLoggerMock.Object);

            //assert
            act
                .ShouldThrow<ArgumentNullException>()
                .Which.ParamName.Should().Be("pager");
        }

        [Fact]
        public void FizzBuzzController_ConstructorWithNullUserInputLogger_ThrowsArgumentNullException()
        {
            //act
            Action act = () => new FizzBuzzController(
                FizzBuzzGeneratorMock.Object,
                SettingsStoreMock.Object,
                PagerMock.Object,
                null);

            //assert
            act
                .ShouldThrow<ArgumentNullException>()
                .Which.ParamName.Should().Be("userInputLogger");
        }

        [Fact]
        public void FizzBuzzController_ConstructorWithValidParameters_DoesNotThrow()
        {
            //act
            Action act = () => new FizzBuzzController(
                FizzBuzzGeneratorMock.Object, 
                SettingsStoreMock.Object,
                PagerMock.Object,
                UserInputLoggerMock.Object);

            //assert
            act.ShouldNotThrow();
        }
    }
}