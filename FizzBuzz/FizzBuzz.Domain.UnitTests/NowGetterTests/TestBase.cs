using FizzBuzz.Domain.Concrete;

namespace FizzBuzz.Domain.UnitTests.NowGetterTests
{
    public class TestBase
    {
        protected NowGetter CreateSut() => new NowGetter(); 
    }
}