using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using static FizzBuzz.Domain.UnitTests.TestHelper;

namespace FizzBuzz.Domain.UnitTests.PagerTests
{
    public class GetPage : TestBase
    {
        [Fact]
        public void Pager_GetPageWhenItemsIsEmpty_ThrowsCorrectException()
        {
            //arrange
            var sut = CreateSut();
            var pageSize = GenerateNumberBetween(20, 30);
            var totalNumberOfPages = GenerateNumberBetween(5, 10);

            //act
            Action act = () => sut.GetPage(new List<string>(), pageSize, totalNumberOfPages);

            //assert
            act.ShouldThrow<InvalidOperationException>().WithMessage("Items cannot be empty");
        }

        [Fact]
        public void Pager_GetPageWhenPageSizeIsLessThanOne_ThrowsCorrectException()
        {
            //arrange
            var sut = CreateSut();
            var pageSize = GenerateNumberBetween(20, 30);
            var totalNumberOfPages = GenerateNumberBetween(5, 10);
            var totalNumberOfItems = pageSize * totalNumberOfPages;
            var items = GenerateMany(totalNumberOfItems, GenerateString);

            //act
            Action act = () => sut.GetPage(items, GenerateNumberBelow(1), totalNumberOfPages);

            //assert
            act.ShouldThrow<InvalidOperationException>().WithMessage("Page size cannot be less than 1");
        }

        [Fact]
        public void Pager_GetPageWhenPageNumberIsLessThanOne_ThrowsCorrectException()
        {
            //arrange
            var sut = CreateSut();
            var pageSize = GenerateNumberBetween(20, 30);
            var totalNumberOfPages = GenerateNumberBetween(5, 10);
            var totalNumberOfItems = pageSize * totalNumberOfPages;
            var items = GenerateMany(totalNumberOfItems, GenerateString);

            //act
            Action act = () => sut.GetPage(items, pageSize, GenerateNumberBelow(1));

            //assert
            act.ShouldThrow<InvalidOperationException>().WithMessage("Page number cannot be less than 1");
        }

        [Fact]
        public void Pager_GetPageWhenPageDoesNotExist_ThrowsCorrectException()
        {
            //arrange
            var sut = CreateSut();
            var pageSize = GenerateNumberBetween(20, 30);
            var totalNumberOfPages = GenerateNumberBetween(5, 10);
            var totalNumberOfItems = pageSize * totalNumberOfPages;
            var items = GenerateMany(totalNumberOfItems, GenerateString);
            var pageNumber = totalNumberOfPages + 1;

            //act
            Action act = () => sut.GetPage(items, pageSize, pageNumber);

            //assert
            act.ShouldThrow<InvalidOperationException>().WithMessage($"Items collection does not contain enough items for the page number '{pageNumber}'");
        }

        [Fact]
        public void Pager_GetPageWhenPageExists_ReturnsPage()
        {
            //arrange
            var sut = CreateSut();
            var pageSize = GenerateNumberBetween(20, 30);
            var totalNumberOfPages = GenerateNumberBetween(5, 10);
            var pageNumber = GenerateNumberBetween(1, totalNumberOfPages);
            var items = new List<string>();
            var expected = new List<string>();
            for (int i = 1; i <= totalNumberOfPages; i++)
            {
                var thisPage = GenerateMany(pageSize, GenerateString).ToList();
                items.AddRange(thisPage);
                if (i == pageNumber) expected = thisPage;
            }
            
            //act
            var result = sut.GetPage(items, pageSize, pageNumber);

            //assert
            result.ShouldAllBeEquivalentTo(
                expected,
                options => options.WithStrictOrdering());
        }
        
        [Fact]
        public void Pager_GetPageWhenPageIsOne_ReturnsFirstPage()
        {
            //arrange
            var sut = CreateSut();
            var pageSize = 1;
            var expected = new[] { GenerateString() };

            //act
            var result = sut.GetPage(expected, pageSize, 1);

            //assert
            result.ShouldAllBeEquivalentTo(
                expected,
                options => options.WithStrictOrdering());
        }
    }
}