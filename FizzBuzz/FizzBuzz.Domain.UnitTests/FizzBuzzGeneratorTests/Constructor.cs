using System;
using FizzBuzz.Domain.Concrete;
using FluentAssertions;
using Xunit;
// ReSharper disable once ObjectCreationAsStatement

namespace FizzBuzz.Domain.UnitTests.FizzBuzzGeneratorTests
{
    public class Constructor : TestBase
    {
        [Fact]
        public void FizzBuzzGenerator_Constructor_DoesNotThrow()
        {
            //act
            Action act = () => new FizzBuzzGenerator();
            
            //assert
            act.ShouldNotThrow();
        }
    }
}