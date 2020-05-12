using System;
using FizzBuzz.EndToEndTests.Automation;

namespace FizzBuzz.EndToEndTests.TestSetup
{
    public abstract class TestBase : IDisposable
    {
        protected readonly FizzBuzzDriver Driver;

        // Ran before each test
        protected TestBase() => Driver = DriverCreator.CreateFizzBuzzDriver();
            
        // Ran after each test
        public void Dispose() => Driver.Close();
    }
}