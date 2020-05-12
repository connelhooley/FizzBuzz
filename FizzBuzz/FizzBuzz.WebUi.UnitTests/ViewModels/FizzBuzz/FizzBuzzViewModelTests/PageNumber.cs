using FluentAssertions;
using Xunit;
using static FizzBuzz.WebUi.UnitTests.TestHelper;

namespace FizzBuzz.WebUi.UnitTests.ViewModels.FizzBuzz.FizzBuzzViewModelTests
{
    public class PageNumber : TestBase
    {
        [Fact]
        public void FizzBuzzViewModel_PageNumberGetterWithNoValueSet_ReturnsOne()
        {
            //arrange
            var sut = CreateSut();

            //act
            var result = sut.PageNumber;

            //assert
            result.Should().Be(1);
        }

        [Fact]
        public void FizzBuzzViewModel_PageNumberGetterWithValueSet_ReturnsSetValue()
        {
            //arrange
            var sut = CreateSut();
            var expected = GenerateNumber();
            sut.PageNumber = expected;

            //act
            var result = sut.PageNumber;

            //assert
            result.Should().Be(expected);
        }
    }
}