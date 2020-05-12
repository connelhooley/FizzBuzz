using System.Threading.Tasks;
using FizzBuzz.Domain.Abstract;

namespace FizzBuzz.Domain.Concrete
{
    public class StubUserInputLogger : IUserInputLogger
    {
        public Task LogAsync(int maxValue, int pageNumber) => Task.CompletedTask;
    }
}