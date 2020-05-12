using System;
using System.Collections.Generic;
using System.Linq;
using FizzBuzz.Domain.Abstract;

namespace FizzBuzz.Domain.Concrete
{
    public class Pager : IPager
    {
        public bool HasPage<T>(IEnumerable<T> items, int pageSize, int pageNumber)
        {
            var array= items as T[] ?? items.ToArray();
            if(!array.Any()) throw new InvalidOperationException("Items cannot be empty");
            if(pageSize < 1) throw new InvalidOperationException("Page size cannot be less than 1");
            if (pageNumber < 1) return false;
            return 
                array.Length >= ((pageNumber-1) * pageSize)+1;
        }

        public IEnumerable<T> GetPage<T>(IEnumerable<T> items, int pageSize, int pageNumber)
        {
            var array = items as T[] ?? items.ToArray();
            if (pageNumber < 1) throw new InvalidOperationException("Page number cannot be less than 1");
            if (!HasPage(array, pageSize, pageNumber)) throw new InvalidOperationException($"Items collection does not contain enough items for the page number '{pageNumber}'");
            return array.Skip((pageNumber-1) * pageSize).Take(pageSize);
        }
    }
}