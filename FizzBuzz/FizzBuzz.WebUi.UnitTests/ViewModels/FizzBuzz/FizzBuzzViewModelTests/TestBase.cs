using FizzBuzz.WebUi.ViewModels.FizzBuzz;

namespace FizzBuzz.WebUi.UnitTests.ViewModels.FizzBuzz.FizzBuzzViewModelTests
{
    public class TestBase
    {
        protected FizzBuzzViewModel CreateSut() => new FizzBuzzViewModel();
    }
}