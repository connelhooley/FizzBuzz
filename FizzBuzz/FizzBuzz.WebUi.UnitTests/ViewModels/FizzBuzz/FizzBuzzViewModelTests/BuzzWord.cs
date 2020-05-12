using FluentAssertions;
using Xunit;

namespace FizzBuzz.WebUi.UnitTests.ViewModels.FizzBuzz.FizzBuzzViewModelTests
{
    public class BuzzWord : TestBase
    {
        [Fact]
        public void FizzBuzzViewModel_BuzzWordGetterWithNoValueSet_ReturnsOne()
        {
            //arrange
            var sut = CreateSut();

            //act
            var result = sut.BuzzWord;

            //assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void FizzBuzzViewModel_BuzzWordGetterWithValueSet_ReturnsSetValue()
        {
            //arrange
            var sut = CreateSut();
            var expected = TestHelper.GenerateString();
            sut.BuzzWord = expected;

            //act
            var result = sut.BuzzWord;

            //assert
            result.Should().Be(expected);
        }
    }
}