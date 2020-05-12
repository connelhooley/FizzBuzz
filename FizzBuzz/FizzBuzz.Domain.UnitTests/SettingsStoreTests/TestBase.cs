using System;
using FizzBuzz.Domain.Abstract;
using FizzBuzz.Domain.Concrete;
using Moq;
using static FizzBuzz.Domain.UnitTests.TestHelper;

namespace FizzBuzz.Domain.UnitTests.SettingsStoreTests
{
    public class TestBase
    {
        protected readonly Mock<INowGetter> NowGetterMock;
        protected DateTime Now;

        public TestBase()
        {
            // Create mocks
            NowGetterMock = new Mock<INowGetter>();
            
            // Values returns from mocks
            Now = GenerateDateTime();

            // Set up mocks
            NowGetterMock
                .Setup(getter => getter.GetNow())
                .Returns(() => Now);
        }

        protected SettingsStore CreateSut() => new SettingsStore(NowGetterMock.Object); 
    }
}