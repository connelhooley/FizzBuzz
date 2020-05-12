using System.Linq;
using FizzBuzz.Domain.Models;
using FluentAssertions;
using Xunit;
using static FizzBuzz.WebUi.UnitTests.TestHelper;

namespace FizzBuzz.WebUi.UnitTests.ViewModels.FizzBuzz.FizzBuzzViewModelTests
{
    public class FizzBuzzItems : TestBase
    {
        [Fact]
        public void FizzBuzzViewModel_FizzBuzzItemsGetterWithNoValueSet_ReturnsOne()
        {
            //arrange
            var sut = CreateSut();

            //act
            var result = sut.FizzBuzzItems;

            //assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void FizzBuzzViewModel_FizzBuzzItemsGetterWithValueSet_ReturnsSetValue()
        {
            //arrange
            var sut = CreateSut();
            var expected = GenerateMany(() => (GenerateNumber(), GenerateEnum<FizzBuzzType>())).ToArray();
            sut.FizzBuzzItems = expected;

            //act
            var result = sut.FizzBuzzItems;

            //assert
            result.Should().BeSameAs(expected);
        }
    }
}