using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FizzBuzz.Domain.Models;

namespace FizzBuzz.WebUi.ViewModels.FizzBuzz
{
    public class FizzBuzzViewModel
    {
        public FizzBuzzViewModel()
        {
            MaxValue = string.Empty;
            FizzWord = string.Empty;
            BuzzWord = string.Empty;
            PageNumber = 1;
            FizzBuzzItems = new List<(int, FizzBuzzType)>();
        }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a number")]
        [Range(1, 1000, ErrorMessage = "Please enter a number between 1 and 1000")]
        public string MaxValue { get; set; }

        public string FizzWord { get; set; }

        public string BuzzWord { get; set; }
        
        public int PageNumber { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public IEnumerable<(int, FizzBuzzType)> FizzBuzzItems { get; set; }
    }
}