using System;
using LibraNetDemo.Models;
using Xunit;

namespace LibraNet.Tests
{
    public class LibraryTests
    {
        [Fact]
        public void BorrowAndReturn_NoFine()
        {
            LibraryManager lib = new LibraryManager(10m);
            lib.AddItem(new Book(1, "Test", "Author", 100));
            BorrowRecord record = lib.BorrowItem(1, 1, "2d");
            decimal fine = lib.ReturnItem(record.RecordId);
            Assert.Equal(0m, fine);
        }

        [Fact]
        public void BorrowAndReturn_WithFine()
        {
            DateTime due = DateTime.Now.AddDays(-3);
            decimal fine = LibraryManager.CalculateFine(due, DateTime.Now, 10m);
            Assert.Equal(30m, fine);
        }

        [Fact]
        public void DurationParser_Works()
        {
            TimeSpan span = DurationParser.Parse("1w 2d 3h");
            Assert.Equal(TimeSpan.FromDays(9).Add(TimeSpan.FromHours(3)), span);
        }

        [Fact]
        public void Audiobook_Play()
        {
            Audiobook ab = new Audiobook(2, "Test Audio", "Author", TimeSpan.FromHours(2));
            ab.Play();
            Assert.Equal(TimeSpan.FromHours(2), ab.Duration);
        }

        [Fact]
        public void EMagazine_Archive()
        {
            EMagazine mag = new EMagazine(3, "Tech", "Ed", 12);
            mag.ArchiveIssue();
            mag.ArchiveIssue();
        }
    }
}
