using System;
using FluentAssertions;
using Xunit;

namespace FizzBuzz.Domain.UnitTests.NowGetterTests
{
    public class GetNow : TestBase
    {
        [Fact]
        public void NowGetter_GenerateWithMinHigherThanMax_ThrowsCorrectException()
        {
            //arrange
            var sut = CreateSut();

            //act
            var result = sut.GetNow();

            //assert
            result.Should().BeCloseTo(DateTime.Now, 5000);
        }
    }
}