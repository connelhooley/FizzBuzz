using FluentAssertions;
using Xunit;
using static FizzBuzz.WebUi.UnitTests.TestHelper;

namespace FizzBuzz.WebUi.UnitTests.ViewModels.FizzBuzz.FizzBuzzViewModelTests
{
    public class HasNextPage : TestBase
    {
        [Fact]
        public void FizzBuzzViewModel_HasNextPageGetterWithNoValueSet_ReturnsOne()
        {
            //arrange
            var sut = CreateSut();

            //act
            var result = sut.HasNextPage;

            //assert
            result.Should().Be(false);
        }

        [Fact]
        public void FizzBuzzViewModel_HasNextPageGetterWithValueSet_ReturnsSetValue()
        {
            //arrange
            var sut = CreateSut();
            var expected = GenerateBool();
            sut.HasNextPage = expected;

            //act
            var result = sut.HasNextPage;

            //assert
            result.Should().Be(expected);
        }
    }
}