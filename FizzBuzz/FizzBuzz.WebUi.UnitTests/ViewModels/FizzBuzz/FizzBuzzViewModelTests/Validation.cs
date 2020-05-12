using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using Xunit;

namespace FizzBuzz.WebUi.UnitTests.ViewModels.FizzBuzz.FizzBuzzViewModelTests
{
    public class Validation : TestBase
    {
        [Fact]
        public void FizzBuzzViewModel_MaxValueIsValid_ModelIsValid()
        {
            //arrange
            var sut = CreateSut();
            sut.MaxValue = TestHelper.GenerateNumberBetween(1, 1000).ToString();

            //act
            var result = Validator.TryValidateObject(
                sut, 
                new ValidationContext(sut, null, null),
                new List<ValidationResult>(), 
                true);

            //assert
            result.Should().BeTrue();
        }

        [Fact]
        public void FizzBuzzViewModel_MaxValueIsValid_ModelErrorsIsEmpty()
        {
            //arrange
            var sut = CreateSut();
            sut.MaxValue = TestHelper.GenerateNumberBetween(1, 1000).ToString();
            var results = new List<ValidationResult>();

            //act
            Validator.TryValidateObject(
                sut,
                new ValidationContext(sut, null, null),
                results,
                true);

            //assert
            results.Should().BeEmpty();
        }
        
        [Fact]
        public void FizzBuzzViewModel_MaxValueIsTooLow_ModelIsNotValid()
        {
            //arrange
            var sut = CreateSut();
            sut.MaxValue = TestHelper.GenerateNumberBelow(1).ToString();

            //act
            var result = Validator.TryValidateObject(
                sut,
                new ValidationContext(sut, null, null),
                new List<ValidationResult>(),
                true);

            //assert
            result.Should().BeFalse();
        }

        [Fact]
        public void FizzBuzzViewModel_MaxValueIsTooLow_ModelErrorsContainsCorrectError()
        {
            //arrange
            var sut = CreateSut();
            sut.MaxValue = TestHelper.GenerateNumberBelow(1).ToString();
            var results = new List<ValidationResult>();

            //act
            Validator.TryValidateObject(
                sut,
                new ValidationContext(sut, null, null),
                results,
                true);

            //assert
            results.ShouldAllBeEquivalentTo(new[]
            {
                new ValidationResult("Please enter a number between 1 and 1000", new []{"MaxValue"}),
            });
        }

        [Fact]
        public void FizzBuzzViewModel_MaxValueIsTooHigh_ModelIsNotValid()
        {
            //arrange
            var sut = CreateSut();
            sut.MaxValue = TestHelper.GenerateNumberAbove(1000).ToString();

            //act
            var result = Validator.TryValidateObject(
                sut,
                new ValidationContext(sut, null, null),
                new List<ValidationResult>(),
                true);

            //assert
            result.Should().BeFalse();
        }

        [Fact]
        public void FizzBuzzViewModel_MaxValueIsTooHigh_ModelErrorsContainsCorrectError()
        {
            //arrange
            var sut = CreateSut();
            sut.MaxValue = TestHelper.GenerateNumberAbove(1000).ToString();
            var results = new List<ValidationResult>();

            //act
            Validator.TryValidateObject(
                sut,
                new ValidationContext(sut, null, null),
                results,
                true);

            //assert
            results.ShouldAllBeEquivalentTo(new[]
            {
                new ValidationResult("Please enter a number between 1 and 1000", new []{"MaxValue"}),
            });
        }

        [Fact]
        public void FizzBuzzViewModel_MaxValueIsNotNumeric_ModelIsNotValid()
        {
            //arrange
            var sut = CreateSut();
            sut.MaxValue = TestHelper.GenerateNumberBelow(1).ToString();

            //act
            var result = Validator.TryValidateObject(
                sut,
                new ValidationContext(sut, null, null),
                new List<ValidationResult>(),
                true);

            //assert
            result.Should().BeFalse();
        }

        [Fact]
        public void FizzBuzzViewModel_MaxValueIsNotNumeric_ModelErrorsContainsCorrectError()
        {
            //arrange
            var sut = CreateSut();
            sut.MaxValue = 
                TestHelper.GenerateStringFrom(TestHelper.AlphabetLower + TestHelper.AlphabetUpper + TestHelper.SpecialChars) + 
                TestHelper.GenerateStringFrom(TestHelper.Numbers) + 
                TestHelper.GenerateStringFrom(TestHelper.AlphabetLower + TestHelper.AlphabetUpper + TestHelper.SpecialChars); 
            var results = new List<ValidationResult>();

            //act
            Validator.TryValidateObject(
                sut,
                new ValidationContext(sut, null, null),
                results,
                true);

            //assert
            results.ShouldAllBeEquivalentTo(new[]
            {
                new ValidationResult("Please enter a number between 1 and 1000", new []{"MaxValue"})
            });
        }

        [Fact]
        public void FizzBuzzViewModel_MaxValueIsDecimal_ModelIsNotValid()
        {
            //arrange
            var sut = CreateSut();
            sut.MaxValue = $"{TestHelper.GenerateNumberBetween(1, 100)}.{TestHelper.GenerateNumberBetween(1, 100)}";

            //act
            var result = Validator.TryValidateObject(
                sut,
                new ValidationContext(sut, null, null),
                new List<ValidationResult>(),
                true);

            //assert
            result.Should().BeFalse();
        }

        [Fact]
        public void FizzBuzzViewModel_MaxValueIsDecimal_ModelErrorsContainsCorrectError()
        {
            //arrange
            var sut = CreateSut();
            sut.MaxValue = $"{TestHelper.GenerateNumberBetween(1, 100)}.{TestHelper.GenerateNumberBetween(1, 100)}";
            var results = new List<ValidationResult>();

            //act
            Validator.TryValidateObject(
                sut,
                new ValidationContext(sut, null, null),
                results,
                true);

            //assert
            results.ShouldAllBeEquivalentTo(new[]
            {
                new ValidationResult("Please enter a number between 1 and 1000", new []{"MaxValue"})
            });
        }

        [Fact]
        public void FizzBuzzViewModel_MaxValueIsEmpty_ModelIsNotValid()
        {
            //arrange
            var sut = CreateSut();
            sut.MaxValue = string.Empty;

            //act
            var result = Validator.TryValidateObject(
                sut,
                new ValidationContext(sut, null, null),
                new List<ValidationResult>(),
                true);

            //assert
            result.Should().BeFalse();
        }

        [Fact]
        public void FizzBuzzViewModel_MaxValueIsEmpty_ModelErrorsContainsCorrectError()
        {
            //arrange
            var sut = CreateSut();
            sut.MaxValue = string.Empty;
            var results = new List<ValidationResult>();

            //act
            Validator.TryValidateObject(
                sut,
                new ValidationContext(sut, null, null),
                results,
                true);

            //assert
            results.ShouldAllBeEquivalentTo(new[]
            {
                new ValidationResult("Please enter a number", new []{"MaxValue"})
            });
        }

        [Fact]
        public void FizzBuzzViewModel_MaxValueIsWhitespace_ModelIsNotValid()
        {
            //arrange
            var sut = CreateSut();
            sut.MaxValue = TestHelper.GenerateWhitespaceString();

            //act
            var result = Validator.TryValidateObject(
                sut,
                new ValidationContext(sut, null, null),
                new List<ValidationResult>(),
                true);

            //assert
            result.Should().BeFalse();
        }

        [Fact]
        public void FizzBuzzViewModel_MaxValueIsWhitespace_ModelErrorsContainsCorrectError()
        {
            //arrange
            var sut = CreateSut();
            sut.MaxValue = TestHelper.GenerateWhitespaceString();
            var results = new List<ValidationResult>();

            //act
            Validator.TryValidateObject(
                sut,
                new ValidationContext(sut, null, null),
                results,
                true);

            //assert
            results.ShouldAllBeEquivalentTo(new[]
            {
                new ValidationResult("Please enter a number", new []{"MaxValue"})
            });
        }
    }
}