using System;
using System.Collections.Generic;
using FizzBuzz.Domain.Models;
using FluentAssertions;
using Xunit;
using static FizzBuzz.Domain.UnitTests.TestHelper;

namespace FizzBuzz.Domain.UnitTests.FizzBuzzGeneratorTests
{
    public class Generate : TestBase
    {
        #region Error handling

        [Fact]
        public void FizzBuzzGenerator_GenerateWithMinHigherThanMax_ThrowsCorrectException()
        {
            //arrange
            var sut = CreateSut();
            var min = GenerateNumberBetween(1, 100);
            var max = GenerateNumberBelow(min);

            //act
            Action act = () => sut.Generate(min, max);

            //assert
            act.ShouldThrow<InvalidOperationException>().WithMessage($"Min value '{min}' cannot be higher than the max value '{max}'");
        }

        [Fact]
        public void FizzBuzzGenerator_GenerateWithMinLessThanOne_ThrowsCorrectException()
        {
            //arrange
            var sut = CreateSut();
            var min = GenerateNumberBelow(1);
            var max = GenerateNumberBetween(1, 100);

            //act
            Action act = () => sut.Generate(min, max);

            //assert
            act.ShouldThrow<InvalidOperationException>().WithMessage($"Min value '{min}' cannot be less than '1'");
        }
        
        #endregion

        #region Golden path

        public static object[][] TestData => new[]
        {
            new object[]
            {
                1, 1, new[]
                {
                    (1, FizzBuzzType.None)
                }
            },
            new object[]
            {
                1, 2, new[]
                {
                    (1, FizzBuzzType.None),
                    (2, FizzBuzzType.None)
                }
            },
            new object[]
            {
                1, 3, new[]
                {
                    (1, FizzBuzzType.None),
                    (2, FizzBuzzType.None),
                    (3, FizzBuzzType.Fizz)
                }
            },
            new object[]
            {
                1, 15, new[]
                {
                    (1, FizzBuzzType.None),
                    (2, FizzBuzzType.None),
                    (3, FizzBuzzType.Fizz),
                    (4, FizzBuzzType.None),
                    (5, FizzBuzzType.Buzz),
                    (6, FizzBuzzType.Fizz),
                    (7, FizzBuzzType.None),
                    (8, FizzBuzzType.None),
                    (9, FizzBuzzType.Fizz),
                    (10, FizzBuzzType.Buzz),
                    (11, FizzBuzzType.None),
                    (12, FizzBuzzType.Fizz),
                    (13, FizzBuzzType.None),
                    (14, FizzBuzzType.None),
                    (15, FizzBuzzType.FizzBuzz)
                }
            },
            new object[]
            {
                9, 15, new[]
                {
                    (9, FizzBuzzType.Fizz),
                    (10, FizzBuzzType.Buzz),
                    (11, FizzBuzzType.None),
                    (12, FizzBuzzType.Fizz),
                    (13, FizzBuzzType.None),
                    (14, FizzBuzzType.None),
                    (15, FizzBuzzType.FizzBuzz)
                }
            },
            new object[]
            {
                3, 3, new[]
                {
                    (3, FizzBuzzType.Fizz)
                }
            }
        };
        
        [Theory]
        [MemberData(nameof(TestData))]
        public void FizzBuzzGenerator_GenerateWithValidValues_ReturnsCorrectResult(int min, int max, IEnumerable<(int, FizzBuzzType)> expected)
        {
            //arrange
            var sut = CreateSut();

            //act
            var result = sut.Generate(min, max);

            //assert
            result.ShouldBeEquivalentTo(
                expected, 
                options => options.WithStrictOrdering());
        }
        
        #endregion
    }
}