using System;

namespace LibraNetDemo.Models
{
    public class Book : LibraryItem
    {
        public int PageCount { get; }
        public Book(int id, string title, string author, int pageCount)
            : base(id, title, author)
        {
            if (pageCount < 0) throw new ArgumentException("pageCount must be non-negative");
            PageCount = pageCount;
        }
    }
}
