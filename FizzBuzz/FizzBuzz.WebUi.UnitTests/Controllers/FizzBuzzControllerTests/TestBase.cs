using System;
using System.Collections.Generic;
using FizzBuzz.Domain.Abstract;
using FizzBuzz.Domain.Models;
using FizzBuzz.WebUi.Controllers;
using Moq;
using static FizzBuzz.WebUi.UnitTests.TestHelper;

namespace FizzBuzz.WebUi.UnitTests.Controllers.FizzBuzzControllerTests
{
    public class TestBase
    {
        protected readonly Mock<IFizzBuzzGenerator> FizzBuzzGeneratorMock;
        protected readonly Mock<ISettingsStore> SettingsStoreMock;
        protected readonly Mock<IPager> PagerMock;
        protected readonly Mock<IUserInputLogger> UserInputLoggerMock;
        protected readonly string GeneratedMaxValue;
        protected string GeneratedFizzWord;
        protected string GeneratedBuzzWord;
        protected IEnumerable<(int, FizzBuzzType)> GeneratedFizzBuzzItems;
        protected int GeneratedPageNumber;
        protected bool GeneratedHasPreviousPage;
        protected bool GeneratedHasNextPage;
        protected IEnumerable<(int, FizzBuzzType)> PagedFizzBuzzItems;

        public TestBase()
        {
            // Create mocks
            FizzBuzzGeneratorMock = new Mock<IFizzBuzzGenerator>();
            SettingsStoreMock = new Mock<ISettingsStore>();
            PagerMock = new Mock<IPager>();
            UserInputLoggerMock = new Mock<IUserInputLogger>();

            // Values passed into sut
            GeneratedMaxValue = GenerateNumber().ToString();
            GeneratedPageNumber = GenerateNumber();

            // Values used by mocks
            GeneratedFizzBuzzItems = GenerateMany(() => (GenerateNumber(), GenerateEnum<FizzBuzzType>()));
            PagedFizzBuzzItems = GenerateMany(() => (GenerateNumber(), GenerateEnum<FizzBuzzType>()));
            GeneratedFizzWord = GenerateString();
            GeneratedBuzzWord = GenerateString();
            GeneratedHasNextPage = GenerateBool();
            GeneratedHasPreviousPage = GenerateBool();

            // Set up mocks
            FizzBuzzGeneratorMock
                .Setup(generator => generator.Generate(1, Convert.ToInt32(GeneratedMaxValue)))
                .Returns(() => GeneratedFizzBuzzItems);
            SettingsStoreMock
                .Setup(store => store.FizzWord)
                .Returns(() => GeneratedFizzWord);
            SettingsStoreMock
                .Setup(store => store.BuzzWord)
                .Returns(() => GeneratedBuzzWord);
            PagerMock
                .Setup(pager => pager.GetPage(GeneratedFizzBuzzItems, 20, GeneratedPageNumber))
                .Returns(() => PagedFizzBuzzItems);
            PagerMock
                .Setup(pager => pager.HasPage(GeneratedFizzBuzzItems, 20, GeneratedPageNumber))
                .Returns(() => true);
            PagerMock
                .Setup(pager => pager.HasPage(GeneratedFizzBuzzItems, 20, GeneratedPageNumber - 1))
                .Returns(() => GeneratedHasPreviousPage);
            PagerMock
                .Setup(pager => pager.HasPage(GeneratedFizzBuzzItems, 20, GeneratedPageNumber + 1))
                .Returns(() => GeneratedHasNextPage);
        }

        protected FizzBuzzController CreateSut() => new FizzBuzzController(
            FizzBuzzGeneratorMock.Object, 
            SettingsStoreMock.Object,
            PagerMock.Object,
            UserInputLoggerMock.Object);
    }
}