using System;
using System.Collections.Generic;
using BookService;

namespace BookUI
{
    public class TestPredicate : IPredicate
    {
        string predicate;

        public TestPredicate(string predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            this.predicate = predicate;
        }

        public bool IsMatch(Book source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.AuthorName == predicate)
            {
                return true;
            }

            return false;
        }
    }

    public class TestComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.CompareTo(y);
        }
    }
}
