using System;
using FizzBuzz.Domain.Abstract;

namespace FizzBuzz.Domain.Concrete
{
    public class NowGetter : INowGetter
    {
        public DateTime GetNow() => DateTime.Now;
    }
}