using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FizzBuzz.Domain.Models;
using FizzBuzz.WebUi.ViewModels.FizzBuzz;
using FluentAssertions;
using FluentAssertions.Mvc;
using Moq;
using Xunit;
using static FizzBuzz.WebUi.UnitTests.TestHelper;

namespace FizzBuzz.WebUi.UnitTests.Controllers.FizzBuzzControllerTests
{
    public class Results : TestBase
    {
        #region Error handling

        [Fact]
        public void FizzBuzzController_ResultsWithNullModel_ThrowsArgumentNullException()
        {
            //arrange
            var sut = CreateSut();

            //act
            Func<Task> act = () => sut.Results(null);

            //assert
            act.ShouldThrow<ArgumentNullException>().Which.ParamName.Should().Be("model");
        }

        [Fact]
        public void FizzBuzzController_ResultsWithGeneratorThrowing_ThrowsSameException()
        {
            //arrange
            var exception = GenerateException();
            FizzBuzzGeneratorMock
                .Setup(generator => generator.Generate(
                    It.IsAny<int>(), 
                    It.IsAny<int>()))
                .Throws(exception);
            var sut = CreateSut();

            //act
            Func<Task> act = () => sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            act
                .ShouldThrow<Exception>()
                .Which.Should().BeSameAs(exception);
        }
        
        [Fact]
        public void FizzBuzzController_ResultsWithSettingsStoreFizzWordThrowing_ThrowsSameException()
        {
            //arrange
            var exception = GenerateException();
            SettingsStoreMock
                .Setup(store => store.FizzWord)
                .Throws(exception);
            var sut = CreateSut();

            //act
            Func<Task> act = () => sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            act
                .ShouldThrow<Exception>()
                .Which.Should().BeSameAs(exception);
        }

        [Fact]
        public void FizzBuzzController_ResultsWithSettingsStoreBuzzWordThrowing_ThrowsSameException()
        {
            //arrange
            var exception = GenerateException();
            SettingsStoreMock
                .Setup(store => store.BuzzWord)
                .Throws(exception);
            var sut = CreateSut();

            //act
            Func<Task> act = () => sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            act
                .ShouldThrow<Exception>()
                .Which.Should().BeSameAs(exception);
        }

        [Fact]
        public void FizzBuzzController_ResultsWithPagerHasCurrentPageThrowing_ThrowsSameException()
        {
            //arrange
            var exception = GenerateException();
            PagerMock
                .Setup(pager => pager.HasPage(It.IsAny<IEnumerable<(int, FizzBuzzType)>>(), It.IsAny<int>(), GeneratedPageNumber))
                .Throws(exception);
            var sut = CreateSut();

            //act
            Func<Task> act = () => sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            act
                .ShouldThrow<Exception>()
                .Which.Should().BeSameAs(exception);
        }

        [Fact]
        public void FizzBuzzController_ResultsWithPagerHasPreviousPageThrowing_ThrowsSameException()
        {
            //arrange
            var exception = GenerateException();
            PagerMock
                .Setup(pager => pager.HasPage(It.IsAny<IEnumerable<(int, FizzBuzzType)>>(), It.IsAny<int>(), GeneratedPageNumber-1))
                .Throws(exception);
            var sut = CreateSut();

            //act
            Func<Task> act = () => sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            act
                .ShouldThrow<Exception>()
                .Which.Should().BeSameAs(exception);
        }

        [Fact]
        public void FizzBuzzController_ResultsWithPagerHasNextPageThrowing_ThrowsSameException()
        {
            //arrange
            var exception = GenerateException();
            PagerMock
                .Setup(pager => pager.HasPage(It.IsAny<IEnumerable<(int, FizzBuzzType)>>(), It.IsAny<int>(), GeneratedPageNumber + 1))
                .Throws(exception);
            var sut = CreateSut();

            //act
            Func<Task> act = () => sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            act
                .ShouldThrow<Exception>()
                .Which.Should().BeSameAs(exception);
        }
        
        [Fact]
        public void FizzBuzzController_ResultsWithPagerGetPageThrowing_ThrowsSameException()
        {
            //arrange
            var exception = GenerateException();
            PagerMock
                .Setup(pager => pager.GetPage(It.IsAny<IEnumerable<(int, FizzBuzzType)>>(), It.IsAny<int>(), It.IsAny<int>()))
                .Throws(exception);
            var sut = CreateSut();

            //act
            Func<Task> act = () => sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            act
                .ShouldThrow<Exception>()
                .Which.Should().BeSameAs(exception);
        }

        [Fact]
        public void FizzBuzzController_ResultsWithLoggerThrowing_ThrowsSameException()
        {
            //arrange
            var exception = GenerateException();
            UserInputLoggerMock
                .Setup(logger => logger.LogAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Throws(exception);
            var sut = CreateSut();

            //act
            Func<Task> act = () => sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            act
                .ShouldThrow<Exception>()
                .Which.Should().BeSameAs(exception);
        }

        #endregion

        #region Valid model

        [Fact]
        public async Task FizzBuzzController_ResultsWithValidModel_ReturnsCorrectView()
        {
            //arrange
            var sut = CreateSut();
            sut.ModelState.Clear();

            //act
            var result = await sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            result.Should().BeViewResult().WithDefaultViewName();
        }

        [Fact]
        public async Task FizzBuzzController_ResultsWithValidModel_SetsCorrectTitleInViewBag()
        {
            //arrange
            var sut = CreateSut();
            sut.ModelState.Clear();

            //act
            var result = await sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            result.Should().BeViewResult().WithViewData("Title", "Results Page");
        }
        
        [Fact]
        public async Task FizzBuzzController_ResultsWithValidModel_ReturnsViewWithCorrectViewModel()
        {
            //arrange
            var sut = CreateSut();
            sut.ModelState.Clear();

            //act
            var result = await sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            result.Should().BeViewResult().ModelAs<FizzBuzzViewModel>().ShouldBeEquivalentTo(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                FizzBuzzItems = PagedFizzBuzzItems,
                FizzWord = GeneratedFizzWord,
                BuzzWord = GeneratedBuzzWord,
                PageNumber = GeneratedPageNumber,
                HasNextPage = GeneratedHasNextPage,
                HasPreviousPage = GeneratedHasPreviousPage
            });
        }
        
        [Fact]
        public async Task FizzBuzzController_ResultsWithValidModel_LogsCorrectUserInput()
        {
            //arrange
            var sut = CreateSut();
            sut.ModelState.Clear();

            //act
            await sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            UserInputLoggerMock
                .Verify(logger => logger.LogAsync(
                    Convert.ToInt32(GeneratedMaxValue), 
                    GeneratedPageNumber));
        }


        [Fact]
        public async Task FizzBuzzController_ResultsWithValidModel_AwaitsLogger()
        {
            //arrange
            var sut = CreateSut();
            sut.ModelState.Clear();
            var isAwaited = false;
            UserInputLoggerMock
                .Setup(logger => logger.LogAsync(Convert.ToInt32(GeneratedMaxValue), GeneratedPageNumber))
                .Returns(() => 
                    Task
                        .Delay(TimeSpan.FromMilliseconds(100))
                        .ContinueWith(task => isAwaited = task.IsCompleted));

            //act
            await sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            isAwaited.Should().BeTrue();
        }

        [Fact]
        public async Task FizzBuzzController_ResultsWithValidModel_LogsUserInputOnce()
        {
            //arrange
            var sut = CreateSut();
            sut.ModelState.Clear();

            //act
            await sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            UserInputLoggerMock.Verify(
                logger => logger.LogAsync(It.IsAny<int>(), It.IsAny<int>()),
                Times.Once);
        }

        [Fact]
        public async Task FizzBuzzController_ResultsWithValidModelButInvalidPageNumber_ReturnsRedirectResultToPageOne()
        {
            //arrange
            PagerMock
                .Setup(pager => pager.HasPage(GeneratedFizzBuzzItems, 20, GeneratedPageNumber))
                .Returns(() => false);
            var sut = CreateSut();
            sut.ModelState.Clear();

            //act
            var result = await sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            result.Should().BeRedirectToRouteResult()
                .WithAction("Results")
                .WithRouteValue("MaxValue", GeneratedMaxValue)
                .WithRouteValue("PageNumber", 1);
        }
        
        [Fact]
        public async Task FizzBuzzController_ResultsWithValidModelButInvalidPageNumber_DoesNotLogUserInputOnce()
        {
            //arrange
            PagerMock
                .Setup(pager => pager.HasPage(GeneratedFizzBuzzItems, 20, GeneratedPageNumber))
                .Returns(() => false);
            var sut = CreateSut();
            sut.ModelState.Clear();

            //act
            await sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            UserInputLoggerMock.Verify(
                logger => logger.LogAsync(It.IsAny<int>(), It.IsAny<int>()),
                Times.Never);
        }

        #endregion

        #region Invalid model

        [Fact]
        public async Task FizzBuzzController_ResultsWithInvalidModel_ReturnsCorrectView()
        {
            //arrange
            var sut = CreateSut();
            sut.ModelState.AddModelError("Some key", "Some error message");

            //act
            var result = await sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            result.Should().BeViewResult().WithDefaultViewName();
        }

        [Fact]
        public async Task FizzBuzzController_ResultsWithInvalidModel_SetsCorrectTitleInViewBag()
        {
            //arrange
            var sut = CreateSut();
            sut.ModelState.AddModelError("Some key", "Some error message");

            //act
            var result = await sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            result.Should().BeViewResult().WithViewData("Title", "Results Page");
        }

        [Fact]
        public async Task FizzBuzzController_ResultsWithInvalidModel_ReturnsViewWithCorrectViewModel()
        {
            //arrange
            var sut = CreateSut();
            sut.ModelState.AddModelError("Some key", "Some error message");

            //act
            var result = await sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            result.Should().BeViewResult().ModelAs<FizzBuzzViewModel>().ShouldBeEquivalentTo(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue
            });
        }

        [Fact]
        public async Task FizzBuzzController_ResultsWithInvalidModel_DoesNotLogUserInputOnce()
        {
            //arrange
            var sut = CreateSut();
            sut.ModelState.AddModelError("Some key", "Some error message");

            //act
            await sut.Results(new FizzBuzzViewModel
            {
                MaxValue = GeneratedMaxValue,
                PageNumber = GeneratedPageNumber
            });

            //assert
            UserInputLoggerMock.Verify(
                logger => logger.LogAsync(It.IsAny<int>(), It.IsAny<int>()),
                Times.Never);
        }
        
        #endregion
    }
}