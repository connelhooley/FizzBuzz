using FluentAssertions;
using Xunit;

namespace FizzBuzz.WebUi.UnitTests.ViewModels.FizzBuzz.FizzBuzzViewModelTests
{
    public class FizzWord : TestBase
    {
        [Fact]
        public void FizzBuzzViewModel_FizzWordGetterWithNoValueSet_ReturnsOne()
        {
            //arrange
            var sut = CreateSut();

            //act
            var result = sut.FizzWord;

            //assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void FizzBuzzViewModel_FizzWordGetterWithValueSet_ReturnsSetValue()
        {
            //arrange
            var sut = CreateSut();
            var expected = TestHelper.GenerateString();
            sut.FizzWord = expected;

            //act
            var result = sut.FizzWord;

            //assert
            result.Should().Be(expected);
        }
    }
}