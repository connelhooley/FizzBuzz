using System;
using System.Collections.Generic;
using System.Linq;
using FizzBuzz.Domain.Models;
using FizzBuzz.EndToEndTests.Extensions;
using FluentAssertions;
using OpenQA.Selenium;

namespace FizzBuzz.EndToEndTests.Automation
{
    public class FizzBuzzDriver
    {
        private readonly Uri _baseUri;
        private readonly IWebDriver _driver;

        public FizzBuzzDriver(Uri baseUri, IWebDriver driver)
        {
            _baseUri = baseUri;
            _driver = driver;
        }

        #region Actions

        public FizzBuzzDriver GoToHomePage()
        {
            _driver.Navigate().GoToUrl(_baseUri);
            return this;
        }

        public FizzBuzzDriver GoTo(string relativeUri)
        {
            _driver.Navigate().GoToUrl(new Uri(_baseUri, relativeUri));
            return this;
        }

        public FizzBuzzDriver GoToNextPage()
        {
            NextPage.Click();
            return this;
        }
        
        public FizzBuzzDriver GoToPreviousPage()
        {
            PreviousPage.Click();
            return this;
        }

        public FizzBuzzDriver SubmitForm(string submittedValue)
        {
            MaxValueInput.Click();
            MaxValueInput.SendKeys(submittedValue);
            MaxValueInput.Submit();
            return this;
        }

        public void Close() => _driver.Quit();

        #endregion

        #region Assertions

        public FizzBuzzDriver ResultsShouldNotBeInTheDom()
        {
            _driver
                .IsElementInDom(By.CssSelector("#results"))
                .Should().BeFalse("because there should be no elements with the class 'results' in the DOM");
            return this;
        }

        public FizzBuzzDriver ResultsShouldBeShown()
        {
            Results
                .Displayed
                .Should().BeTrue("because the results element should be displayed on user's screen");
            return this;
        }
        
        public FizzBuzzDriver ResultsShouldBe(params FizzBuzzType[] expected)
        {
            var actual = Results
                .FindElements(By.CssSelector(".item"))
                .Select(e =>
                {
                    var isFizz = e.ContainsChild(By.CssSelector(".fizz"));
                    var isBuzz = e.ContainsChild(By.CssSelector(".buzz"));
                    if (isFizz && isBuzz)
                    {
                        return FizzBuzzType.FizzBuzz;
                    }
                    if (isFizz)
                    {
                        return FizzBuzzType.Fizz;
                    }
                    if (isBuzz)
                    {
                        return FizzBuzzType.Buzz;
                    }
                    return FizzBuzzType.None;
                });
            actual.ShouldAllBeEquivalentTo(
                expected,
                options => options.WithStrictOrdering(),
                "because this is what should be displayed in the results");
            return this;
        }

        public FizzBuzzDriver ErrorMessageShouldNotBeShown()
        {
            Error
                .GetClasses()
                .Should().NotContain(
                    "field-validation-error", 
                    "because the error element should not contain this class when it is not shown");
            Error
                .GetClasses()
                .Should().Contain(
                    "field-validation-valid", 
                    "because the error element should not contain this class when it is not shown");
            Error
                .Displayed
                .Should().BeFalse("because the error element should be in the DOM, but not shown on the user's screen");
            return this;
        }

        public FizzBuzzDriver ErrorMessageShouldBeShown(string expectedMessage)
        {
            Error
                .GetClasses()
                .Should().Contain(
                    "field-validation-error",
                    "because the error element should contain this class when it is shown");
            Error
                .GetClasses()
                .Should().NotContain(
                    "field-validation-valid",
                    "because the error element should not contain this class when it is shown");
            Error
                .Displayed
                .Should().BeTrue("because the error element should be displayed on user's screen");
            Error
                .Text
                .Should().Be(
                    expectedMessage,
                    "because this is what should be displayed to the user in the error message");
            return this;
        }

        public FizzBuzzDriver TextBoxValueShouldBe(string expectedValue)
        {
            MaxValueInput
                .GetAttribute("value")
                .Should().Be(
                    expectedValue, 
                    "because this is the value that the text box should contain");
            return this;
        }
        
        public FizzBuzzDriver UrlShouldBeTheHomePage()
        {
            _driver.Url.Should().Be(
                _baseUri.ToString(),
                "because the URL that the webpage is on should be the home page");
            return this;
        }

        public FizzBuzzDriver UrlShouldBe(string expectedRelativeUrl)
        {
            _driver.Url.Should().Be(
                new Uri(_baseUri, expectedRelativeUrl).ToString(), 
                "because this is the URL that the webpage should be on");
            return this;
        }

        public FizzBuzzDriver TitleShouldBe(string expectedTitle)
        {
            _driver.Title.Should().Be(
                expectedTitle,
                "because this is what the title of the webpage should be");
            return this;
        }
        
        public FizzBuzzDriver CurrentPageNumberShouldBe(string expectedPageNuber)
        {
            CurrentPageNumber.Text.Should().Be(
                expectedPageNuber,
                "because this is what the current page number should be");
            return this;
        }
        
        public FizzBuzzDriver CurrentMaxValueShouldBe(string expectedCurrentMaxValue)
        {
            CurrentMaxValue.Text.Should().Be(
                expectedCurrentMaxValue,
                "because this is what the current max value should be");
            return this;
        }

        public FizzBuzzDriver NextPageLinkShouldBeEnabled()
        {
            NextPage
                .GetClasses()
                .Should().NotContain(
                    "disabled",
                    "because the next page link should not look disabled on user's screen");
            NextPage
                .TagName
                .Should().Be(
                    "a",
                    "because the next page link should be a hyper link");
            return this;
        }

        public FizzBuzzDriver PreviousPageLinkShouldBeEnabled()
        {
            PreviousPage
                .GetClasses()
                .Should().NotContain(
                    "disabled",
                    "because the previous page link should not look disabled on user's screen");
            PreviousPage
                .TagName
                .Should().Be(
                    "a",
                    "because the previous page link should be a hyper link");
            return this;
        }

        public FizzBuzzDriver NextPageLinkShouldNotBeEnabled()
        {
            NextPage
                .GetClasses()
                .Should().Contain(
                    "disabled",
                    "because the next page link should look disabled on user's screen");
            NextPage
                .TagName
                .Should().Be(
                    "div",
                    "because the next page link should not be a hyper link");
            return this;
        }

        public FizzBuzzDriver PreviousPageLinkShouldNotBeEnabled()
        {
            PreviousPage
                .GetClasses()
                .Should().Contain(
                    "disabled",
                    "because the previous page link should look disabled on user's screen");
            PreviousPage
                .TagName
                .Should().Be(
                    "div",
                    "because the previous page link should not be a hyper link");
            return this;
        }

        public FizzBuzzDriver PagerShouldNotBeInTheDom()
        {
            _driver
                .IsElementInDom(By.CssSelector(".pager"))
                .Should().BeFalse("because there should be no elements with the class 'results' in the DOM");
            return this;
        }

        #endregion

        private IWebElement MaxValueInput =>
            _driver.FindElement(By.CssSelector("form input#MaxValue"));

        private IWebElement Error =>
            _driver.FindElement(By.CssSelector("#max-value-error"));

        private IWebElement Results =>
            _driver.FindElement(By.CssSelector("#results"));
        
        private IWebElement CurrentMaxValue =>
            _driver.FindElement(By.CssSelector("#current-max-value"));

        private IWebElement CurrentPageNumber =>
            _driver.FindElement(By.CssSelector("#results .pager .current-page .current-page-number"));

        private IWebElement NextPage =>
            _driver.FindElement(By.CssSelector("#results .pager .page-links .next-page"));

        private IWebElement PreviousPage =>
            _driver.FindElement(By.CssSelector("#results .pager .page-links .previous-page"));
    }
}