using FizzBuzz.Domain.Models;
using FizzBuzz.EndToEndTests.TestSetup;
using Xunit;

namespace FizzBuzz.EndToEndTests
{
    public class ResultsPageTests : TestBase
    {
        [Fact]
        public void ResultsPage_ValidatesCorrectly_NoMaxValue() => Driver
            .GoTo("/FizzBuzz/Results")
            .TitleShouldBe("Results Page")
            .ErrorMessageShouldBeShown("Please enter a number")
            .ResultsShouldNotBeInTheDom()
            .TextBoxValueShouldBe(string.Empty);

        [Fact]
        public void ResultsPage_ValidatesCorrectly_InvalidMaxValue() => Driver
            .GoTo("/FizzBuzz/Results?MaxValue=helloworld")
            .TitleShouldBe("Results Page")
            .ErrorMessageShouldBeShown("Please enter a number between 1 and 1000")
            .ResultsShouldNotBeInTheDom()
            .TextBoxValueShouldBe(string.Empty);

        [Fact]
        public void ResultsPage_RedirectsCorrectly_HighPageNumber() => Driver
            .GoTo("/FizzBuzz/Results?MaxValue=5&PageNumber=2")
            .TitleShouldBe("Results Page")
            .UrlShouldBe("/FizzBuzz/Results?MaxValue=5&PageNumber=1");

        [Fact]
        public void ResultsPage_RedirectsCorrectly_LowPageNumber() => Driver
            .GoTo("/FizzBuzz/Results?MaxValue=5&PageNumber=-5")
            .UrlShouldBe("/FizzBuzz/Results?MaxValue=5&PageNumber=1");

        [Fact]
        public void ResultsPage_DisplaysCorrectly_FirstPage() => Driver
            .GoTo("/FizzBuzz/Results?MaxValue=209")
            .TitleShouldBe("Results Page")
            .PreviousPageLinkShouldNotBeEnabled()
            .NextPageLinkShouldBeEnabled()
            .CurrentMaxValueShouldBe("209")
            .CurrentPageNumberShouldBe("1")
            .ResultsShouldBe(
                FizzBuzzType.None,
                FizzBuzzType.None,
                FizzBuzzType.Fizz,
                FizzBuzzType.None,
                FizzBuzzType.Buzz,
                FizzBuzzType.Fizz,
                FizzBuzzType.None,
                FizzBuzzType.None,
                FizzBuzzType.Fizz,
                FizzBuzzType.Buzz,
                FizzBuzzType.None,
                FizzBuzzType.Fizz,
                FizzBuzzType.None,
                FizzBuzzType.None,
                FizzBuzzType.FizzBuzz,
                FizzBuzzType.None,
                FizzBuzzType.None,
                FizzBuzzType.Fizz,
                FizzBuzzType.None,
                FizzBuzzType.Buzz);

        [Fact]
        public void ResultsPage_DisplaysCorrectly_MiddlePage() => Driver
            .GoTo("/FizzBuzz/Results?MaxValue=209&PageNumber=5")
            .TitleShouldBe("Results Page")
            .PreviousPageLinkShouldBeEnabled()
            .NextPageLinkShouldBeEnabled()
            .CurrentMaxValueShouldBe("209")
            .CurrentPageNumberShouldBe("5")
            .ResultsShouldBe(
                FizzBuzzType.Fizz,
                FizzBuzzType.None,
                FizzBuzzType.None,
                FizzBuzzType.Fizz,
                FizzBuzzType.Buzz,
                FizzBuzzType.None,
                FizzBuzzType.Fizz,
                FizzBuzzType.None,
                FizzBuzzType.None,
                FizzBuzzType.FizzBuzz,
                FizzBuzzType.None,
                FizzBuzzType.None,
                FizzBuzzType.Fizz,
                FizzBuzzType.None,
                FizzBuzzType.Buzz,
                FizzBuzzType.Fizz,
                FizzBuzzType.None,
                FizzBuzzType.None,
                FizzBuzzType.Fizz,
                FizzBuzzType.Buzz);
        
        [Fact]
        public void ResultsPage_DisplaysCorrectly_LastPage() => Driver
            .GoTo("/FizzBuzz/Results?MaxValue=209&PageNumber=11")
            .TitleShouldBe("Results Page")
            .PreviousPageLinkShouldBeEnabled()
            .NextPageLinkShouldNotBeEnabled()
            .CurrentMaxValueShouldBe("209")
            .CurrentPageNumberShouldBe("11")
            .ResultsShouldBe(
                FizzBuzzType.Fizz,
                FizzBuzzType.None,
                FizzBuzzType.None,
                FizzBuzzType.Fizz,
                FizzBuzzType.Buzz,
                FizzBuzzType.None,
                FizzBuzzType.Fizz,
                FizzBuzzType.None,
                FizzBuzzType.None);

        [Fact]
        public void ResultsPage_PagerNavigatesCorrectly_NextPage() => Driver
            .GoTo("/FizzBuzz/Results?MaxValue=200&PageNumber=5")
            .GoToNextPage()
            .UrlShouldBe("/FizzBuzz/Results?MaxValue=200&PageNumber=6");
        
        [Fact]
        public void ResultsPage_PagerNavigatesCorrectly_PreviousPage() => Driver
            .GoTo("/FizzBuzz/Results?MaxValue=200&PageNumber=5")
            .GoToPreviousPage()
            .UrlShouldBe("/FizzBuzz/Results?MaxValue=200&PageNumber=4");

        [Fact]
        public void ResultsPage_PagerisNotRendered_SinglePage() => Driver
            .GoTo("/FizzBuzz/Results?MaxValue=19")
            .PagerShouldNotBeInTheDom();
    }
}
