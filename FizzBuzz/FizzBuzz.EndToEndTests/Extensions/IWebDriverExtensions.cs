using OpenQA.Selenium;
// ReSharper disable InconsistentNaming

namespace FizzBuzz.EndToEndTests.Extensions
{
    public static  class IWebDriverExtensions
    {
        public static bool IsElementInDom(this IWebDriver @this, By by)
        {
            try
            {
                @this.FindElement(by);
                return true;
            }
            catch (NotFoundException)
            {
                return false;
            }
        }
    }
}