using System;
using FizzBuzz.Domain.Abstract;

namespace FizzBuzz.Domain.Concrete
{
    public class SettingsStore : ISettingsStore
    {
        private readonly INowGetter _nowGetter;

        public SettingsStore(INowGetter nowGetter) => 
            _nowGetter = nowGetter ?? throw new ArgumentNullException(nameof(nowGetter));

        public string FizzWord =>
            _nowGetter.GetNow().DayOfWeek == DayOfWeek.Wednesday
                ? "wizz"
                : "fizz";

        public string BuzzWord =>
            _nowGetter.GetNow().DayOfWeek == DayOfWeek.Wednesday
                ? "wuzz"
                : "buzz";
    }
}