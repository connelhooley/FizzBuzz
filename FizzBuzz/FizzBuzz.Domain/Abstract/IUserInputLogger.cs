using System.Threading.Tasks;

namespace FizzBuzz.Domain.Abstract
{
    public interface IUserInputLogger
    {
        Task LogAsync(int maxValue, int pageNumber);
    }
}