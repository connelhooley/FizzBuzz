using FizzBuzz.EndToEndTests.TestSetup;
using Xunit;

namespace FizzBuzz.EndToEndTests
{
    public class HomePageTests : TestBase
    {
        [Fact]
        public void HomePage_DisplaysCorrectly() => Driver
            .GoToHomePage()
            .TitleShouldBe("Home Page")
            .ErrorMessageShouldNotBeShown()
            .ResultsShouldNotBeInTheDom()
            .TextBoxValueShouldBe(string.Empty);

        [Fact]
        public void HomePage_ValidatesCorrectly() => Driver
            .GoToHomePage()
            .SubmitForm("-5")
            .UrlShouldBeTheHomePage()
            .ErrorMessageShouldBeShown("Please enter a number between 1 and 1000")
            .ResultsShouldNotBeInTheDom()
            .TextBoxValueShouldBe("-5");

        [Fact]
        public void HomePage_SubmitsCorrectly() => Driver
            .GoToHomePage()
            .SubmitForm("10")
            .UrlShouldBe("/FizzBuzz/Results?MaxValue=10")
            .ErrorMessageShouldNotBeShown()
            .TextBoxValueShouldBe("10")
            .ResultsShouldBeShown();
    }
}
