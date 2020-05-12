using System;
using FizzBuzz.Domain.Concrete;
using FluentAssertions;
using Xunit;
// ReSharper disable once ObjectCreationAsStatement

namespace FizzBuzz.Domain.UnitTests.PagerTests
{
    public class Constructor : TestBase
    {
        [Fact]
        public void Pager_Constructor_DoesNotThrow()
        {
            //act
            Action act = () => new Pager();
            
            //assert
            act.ShouldNotThrow();
        }
    }
}