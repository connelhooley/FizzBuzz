using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using static FizzBuzz.Domain.UnitTests.TestHelper;

namespace FizzBuzz.Domain.UnitTests.PagerTests
{
    public class HasPage : TestBase
    {
        [Fact]
        public void Pager_HasPageWhenItemsIsEmpty_ThrowsCorrectException()
        {
            //arrange
            var sut = CreateSut();
            var pageSize = GenerateNumberBetween(20, 30);
            var totalNumberOfPages = GenerateNumberBetween(5, 10);

            //act
            Action act = () => sut.HasPage(new List<string>(), pageSize, totalNumberOfPages);

            //assert
            act.ShouldThrow<InvalidOperationException>().WithMessage("Items cannot be empty");
        }

        [Fact]
        public void Pager_HasPageWhenPageSizeIsLessThanOne_ThrowsCorrectException()
        {
            //arrange
            var sut = CreateSut();
            var pageSize = GenerateNumberBetween(20, 30);
            var totalNumberOfPages = GenerateNumberBetween(5, 10);
            var totalNumberOfItems = pageSize * totalNumberOfPages;
            var items = GenerateMany(totalNumberOfItems, GenerateString);

            //act
            Action act = () => sut.HasPage(items, GenerateNumberBelow(1), totalNumberOfPages);

            //assert
            act.ShouldThrow<InvalidOperationException>().WithMessage("Page size cannot be less than 1");
        }

        [Fact]
        public void Pager_HasPageWhenPageNumberIsLessThanOne_ReturnsFalse()
        {
            //arrange
            var sut = CreateSut();
            var pageSize = GenerateNumberBetween(20, 30);
            var totalNumberOfPages = GenerateNumberBetween(5, 10);
            var totalNumberOfItems = pageSize * totalNumberOfPages;
            var items = GenerateMany(totalNumberOfItems, GenerateString);

            //act
            var result = sut.HasPage(items, pageSize, GenerateNumberBelow(1));

            //assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Pager_HasPageWhenPageDoesNotExist_ReturnsFalse()
        {
            //arrange
            var sut = CreateSut();
            var pageSize = GenerateNumberBetween(20, 30);
            var totalNumberOfPages = GenerateNumberBetween(5, 10);
            var totalNumberOfItems = pageSize * totalNumberOfPages;
            var items = GenerateMany(totalNumberOfItems, GenerateString);

            //act
            var result = sut.HasPage(items, pageSize, totalNumberOfPages + 1);

            //assert
            result.Should().BeFalse();
        }
        
        [Fact]
        public void Pager_HasPageWhenPageDoesExist_ReturnsTrue()
        {
            //arrange
            var sut = CreateSut();
            var pageSize = GenerateNumberBetween(20,30);
            var totalNumberOfPages = GenerateNumberBetween(5, 10);
            var totalNumberOfItems = pageSize * totalNumberOfPages;
            var items = GenerateMany(totalNumberOfItems, GenerateString);

            //act
            var result = sut.HasPage(items, pageSize, GenerateNumberBetween(2, totalNumberOfPages));

            //assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Pager_HasPageWhenPageIsOne_ReturnsTrue()
        {
            //arrange
            var sut = CreateSut();
            var pageSize = 1;
            var items = new []{ GenerateString()};

            //act
            var result = sut.HasPage(items, pageSize, 1);

            //assert
            result.Should().BeTrue();
        }
    }
}