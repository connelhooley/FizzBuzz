using System;
using FizzBuzz.WebUi.ViewModels.FizzBuzz;
using FluentAssertions;
using Xunit;
// ReSharper disable ObjectCreationAsStatement

namespace FizzBuzz.WebUi.UnitTests.ViewModels.FizzBuzz.FizzBuzzViewModelTests
{
    public class Constructor : TestBase
    {
        [Fact]
        public void FizzBuzzViewModel_Constructor_DoesNotThrow()
        {
            //act
            Action act = () => new FizzBuzzViewModel();

            //assert
            act.ShouldNotThrow();
        }
    }
}