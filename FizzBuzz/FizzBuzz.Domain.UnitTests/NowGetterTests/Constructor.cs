using System;
using FizzBuzz.Domain.Concrete;
using FluentAssertions;
using Xunit;
// ReSharper disable once ObjectCreationAsStatement

namespace FizzBuzz.Domain.UnitTests.NowGetterTests
{
    public class Constructor : TestBase
    {
        [Fact]
        public void NowGetter_Constructor_DoesNotThrow()
        {
            //act
            Action act = () => new NowGetter();
            
            //assert
            act.ShouldNotThrow();
        }
    }
}