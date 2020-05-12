using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz.Domain.UnitTests
{
    public static class TestHelper
    {
        private static readonly Random Random = new Random();

        public const string AlphabetLower = "abcdefghijklmnopqrstuvwxyz";
        public const string AlphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string Numbers = "0123456789";
        public const string AlphaNumeric = AlphabetLower + AlphabetUpper + Numbers;
        public const string SpecialChars = "!\"£$%^&*()_+=-{}][:';'<>?,./|\\";

        public static Exception GenerateException() =>
            new Exception(GenerateString());
        
        public static bool GenerateBool() =>
            Random.NextDouble() >= 0.5;
        
        public static DateTime GenerateDateTime() =>
            DateTime.Today.AddDays(GenerateNumberBetween(-1000, 1000));

        public static DateTime GenerateDateTimeByWeekDay(DayOfWeek dayOfWeek)
        {
            var result = GenerateDateTime();
            while (result.DayOfWeek != dayOfWeek)
            {
                result = result.AddDays(1);
            }
            return result;
        }

        public static int GenerateNumber() =>
            Random.Next();

        public static int GenerateNumberBelow(int value) =>
            Random.Next(int.MinValue, value);

        public static int GenerateNumberAbove(int value) =>
            Random.Next(value + 1, int.MaxValue);

        public static int GenerateNumberBetween(int min, int max) =>
            Random.Next(min, max + 1);

        public static T ChooseRandomItem<T>(IEnumerable<T> items)
        {
            var list = items as List<T> ?? items.ToList();
            var index = Random.Next(list.Count);
            return list[index];
        }

        public static string GenerateString() =>
            GenerateStringFrom(AlphaNumeric + SpecialChars);

        public static string GenerateStringFrom(string chars) =>
            string.Join(
                string.Empty,
                Enumerable
                    .Repeat(0, Random.Next(1, 50))
                    .Select(i => ChooseRandomItem(chars)));

        public static string GenerateWhitespaceString() =>
            string.Join(string.Empty, Enumerable.Repeat(" ", Random.Next(1, 50)));

        public static IEnumerable<T> GenerateMany<T>(Func<T> creator) =>
            Enumerable
                .Range(1, Random.Next(2, 101))
                .Select(i => creator());

        public static IEnumerable<T> GenerateMany<T>(int count, Func<T> creator) =>
            Enumerable
                .Range(1, count)
                .Select(i => creator());
        
        public static T GenerateEnum<T>() where T : struct
        {
            if (!typeof(T).IsEnum) throw new InvalidOperationException("Not an enum");
            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(Random.Next(values.Length));
        }
    }
}