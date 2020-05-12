using FluentAssertions;
using Xunit;
using static FizzBuzz.WebUi.UnitTests.TestHelper;

namespace FizzBuzz.WebUi.UnitTests.ViewModels.FizzBuzz.FizzBuzzViewModelTests
{
    public class HasPreviousPage : TestBase
    {
        [Fact]
        public void FizzBuzzViewModel_HasPreviousPageGetterWithNoValueSet_ReturnsOne()
        {
            //arrange
            var sut = CreateSut();

            //act
            var result = sut.HasPreviousPage;

            //assert
            result.Should().Be(false);
        }

        [Fact]
        public void FizzBuzzViewModel_HasPreviousPageGetterWithValueSet_ReturnsSetValue()
        {
            //arrange
            var sut = CreateSut();
            var expected = GenerateBool();
            sut.HasPreviousPage = expected;

            //act
            var result = sut.HasPreviousPage;

            //assert
            result.Should().Be(expected);
        }
    }
}