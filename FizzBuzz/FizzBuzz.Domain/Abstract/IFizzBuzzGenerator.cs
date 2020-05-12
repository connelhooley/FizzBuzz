using System.Collections.Generic;
using FizzBuzz.Domain.Models;

namespace FizzBuzz.Domain.Abstract
{
    public interface IFizzBuzzGenerator
    {
        IEnumerable<(int, FizzBuzzType)> Generate(int min, int max);
    }
}