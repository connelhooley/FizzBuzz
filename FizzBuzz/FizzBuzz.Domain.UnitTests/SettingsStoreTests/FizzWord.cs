using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using static FizzBuzz.Domain.UnitTests.TestHelper;

namespace FizzBuzz.Domain.UnitTests.SettingsStoreTests
{
    public class FizzWord : TestBase
    {
        [Theory]
        [InlineData(DayOfWeek.Monday)]
        [InlineData(DayOfWeek.Tuesday)]
        [InlineData(DayOfWeek.Thursday)]
        [InlineData(DayOfWeek.Friday)]
        [InlineData(DayOfWeek.Saturday)]
        [InlineData(DayOfWeek.Sunday)]
        public void SettingsStore_FizzWordNotOnAWednesday_ReturnsCorrectValue(DayOfWeek dayOfWeek)
        {
            //arrange
            Now = GenerateDateTimeByWeekDay(dayOfWeek);
            var sut = CreateSut();

            //act
            var result = sut.FizzWord;

            //assert
            result.Should().Be("fizz");
        }

        [Fact]
        public void SettingsStore_FizzWordOnAWednesday_ReturnsCorrectValue()
        {
            //arrange
            Now = GenerateDateTimeByWeekDay(DayOfWeek.Wednesday);
            var sut = CreateSut();

            //act
            var result = sut.FizzWord;

            //assert
            result.Should().Be("wizz");
        }
        
        [Fact]
        public void SettingsStore_FizzWordAlwaysUsesCurrentNow_ReturnsCorrectValue()
        {
            //arrange
            var sut = CreateSut();
            var randomDays = GenerateMany(() => 
                GenerateBool()
                    ? DayOfWeek.Tuesday 
                    : DayOfWeek.Wednesday)
                .ToArray();
            var expected = randomDays.Select(day => day == 
                DayOfWeek.Tuesday 
                    ? "fizz" 
                    : "wizz");
            List<string> result = new List<string>();
            
            //act
            foreach (var randomDay in randomDays)
            {
                Now = GenerateDateTimeByWeekDay(randomDay);
                result.Add(sut.FizzWord);
            }

            //assert
            result.ShouldAllBeEquivalentTo(
                expected, 
                options => options.WithStrictOrdering());
        }
    }
}