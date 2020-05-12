using System;
using System.Collections.Generic;
using System.Linq;
using FizzBuzz.Domain.Abstract;
using FizzBuzz.Domain.Models;

namespace FizzBuzz.Domain.Concrete
{
    public class FizzBuzzGenerator : IFizzBuzzGenerator
    {
        public IEnumerable<(int, FizzBuzzType)> Generate(int min, int max)
        {
            if (min < 1)
            {
                throw new InvalidOperationException($"Min value '{min}' cannot be less than '1'");
            }
            if (min > max)
            {
                throw new InvalidOperationException($"Min value '{min}' cannot be higher than the max value '{max}'");
            }
            return Enumerable
                .Range(min, max - min + 1)
                .Select(i =>
                {
                    switch (i)
                    {
                        case var _ when i % 3 == 0 && i % 5 == 0:
                            return (i, FizzBuzzType.FizzBuzz);
                        case var _ when i % 3 == 0:
                            return (i, FizzBuzzType.Fizz);
                        case var _ when i % 5 == 0:
                            return (i, FizzBuzzType.Buzz);
                        default:
                            return (i, FizzBuzzType.None);
                    }
                });
        }
    }
}