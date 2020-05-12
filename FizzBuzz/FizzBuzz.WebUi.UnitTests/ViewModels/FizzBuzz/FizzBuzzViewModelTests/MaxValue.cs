using FluentAssertions;
using Xunit;

namespace FizzBuzz.WebUi.UnitTests.ViewModels.FizzBuzz.FizzBuzzViewModelTests
{
    public class MaxValue : TestBase
    {
        [Fact]
        public void FizzBuzzViewModel_MaxValueGetterWithNoValueSet_ReturnsOne()
        {
            //arrange
            var sut = CreateSut();

            //act
            var result = sut.MaxValue;

            //assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void FizzBuzzViewModel_MaxValueGetterWithValueSet_ReturnsSetValue()
        {
            //arrange
            var sut = CreateSut();
            var expected = TestHelper.GenerateString();
            sut.MaxValue = expected;

            //act
            var result = sut.MaxValue;

            //assert
            result.Should().Be(expected);
        }
    }
}