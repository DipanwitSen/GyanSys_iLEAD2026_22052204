using System;

namespace LibraNetDemo.Models
{
    public abstract class LibraryItem
    {
        public int Id { get; }
        public string Title { get; }
        public string Author { get; }
        public bool IsAvailable { get; private set; } = true;

        protected LibraryItem(int id, string title, string author)
        {
            if (id <= 0) throw new ArgumentException("id must be positive");
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Author = author ?? throw new ArgumentNullException(nameof(author));
        }

        public void MarkBorrowed()
        {
            if (!IsAvailable) throw new InvalidOperationException("Item already borrowed");
            IsAvailable = false;
        }

        public void MarkReturned()
        {
            IsAvailable = true;
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1} by {2} (available={3})", Id, Title, Author, IsAvailable);
        }
    }
}
