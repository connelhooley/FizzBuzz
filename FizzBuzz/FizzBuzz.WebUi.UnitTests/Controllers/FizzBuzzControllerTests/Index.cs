using FizzBuzz.WebUi.ViewModels.FizzBuzz;
using FluentAssertions;
using FluentAssertions.Mvc;
using Xunit;

namespace FizzBuzz.WebUi.UnitTests.Controllers.FizzBuzzControllerTests
{
    public class Index : TestBase
    {
        [Fact]
        public void FizzBuzzController_Index_ReturnsCorrectView()
        {
            //arrange
            var sut = CreateSut();

            //act
            var result = sut.Index();

            //assert
            result.Should().BeViewResult().WithViewName("Results");
        }

        [Fact]
        public void FizzBuzzController_Index_SetsCorrectTitleInViewBag()
        {
            //arrange
            var sut = CreateSut();

            //act
            var result = sut.Index();

            //assert
            result.Should().BeViewResult().WithViewData("Title", "Home Page");
        }

        [Fact]
        public void FizzBuzzController_Index_ReturnsViewWithCorrectViewModel()
        {
            //arrange
            var sut = CreateSut();

            //act
            var result = sut.Index();

            //assert
            result.Should().BeViewResult().ModelAs<FizzBuzzViewModel>().ShouldBeEquivalentTo(new FizzBuzzViewModel());
        }
    }
}