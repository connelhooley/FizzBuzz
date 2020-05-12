using OpenQA.Selenium;
// ReSharper disable InconsistentNaming

namespace FizzBuzz.EndToEndTests.Extensions
{
    public static  class IWebElementExtensions
    {
        public static string[] GetClasses(this IWebElement @this) =>
            @this.GetAttribute("class").Split();
        
        public static bool ContainsChild(this IWebElement @this, By by)
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