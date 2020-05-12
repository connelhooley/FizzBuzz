using FizzBuzz.Domain.Concrete;

namespace FizzBuzz.Domain.UnitTests.FizzBuzzGeneratorTests
{
    public class TestBase
    {
        protected FizzBuzzGenerator CreateSut() => new FizzBuzzGenerator(); 
    }
}