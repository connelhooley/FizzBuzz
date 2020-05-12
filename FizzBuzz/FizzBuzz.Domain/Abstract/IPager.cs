using System.Collections.Generic;

namespace FizzBuzz.Domain.Abstract
{
    public interface IPager
    {
        IEnumerable<T> GetPage<T>(IEnumerable<T> items, int pageSize, int pageNumber);
        bool HasPage<T>(IEnumerable<T> items, int pageSize, int pageNumber);
    }
}