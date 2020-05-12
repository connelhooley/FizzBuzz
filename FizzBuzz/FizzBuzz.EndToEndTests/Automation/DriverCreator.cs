using System;
using System.Configuration;
using OpenQA.Selenium.Chrome;

namespace FizzBuzz.EndToEndTests.Automation
{
    public static class DriverCreator
    {
        private static ChromeOptions ChromeOptions
        {
            get
            {
                var options = new ChromeOptions();
                options.AddArgument("headless");
                options.AddArgument("disable-gpu");
                return options;
            }
        }

        private static Uri BaseUri => 
            new Uri(ConfigurationManager.AppSettings["BaseUri"]);
        
        public static FizzBuzzDriver CreateFizzBuzzDriver() => new FizzBuzzDriver(
            BaseUri,
            new ChromeDriver(ChromeOptions));
    }
}