using System;

namespace FizzBuzz.Domain.Abstract
{
    public interface INowGetter
    {
        DateTime GetNow();
    }
}