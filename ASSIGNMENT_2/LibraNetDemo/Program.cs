using System;
using LibraNetDemo.Models;

namespace LibraNetDemo
{
    class Program
    {
        static void Main()
        {
            LibraryManager lib = new LibraryManager(10m);
            lib.AddItem(new Book(1, "The Hobbit", "Tolkien", 310));
            lib.AddItem(new Audiobook(2, "1984", "Orwell", TimeSpan.FromHours(11).Add(TimeSpan.FromMinutes(30))));
            lib.AddItem(new EMagazine(3, "Tech Today", "Editorial", 55));
            BorrowRecord rec = lib.BorrowItem(1, 1001, "7d");
            Console.WriteLine("Borrowed: " + rec.ToString());
            Audiobook ab = (Audiobook)lib.GetItem(2);
            ab.Play();
            EMagazine mag = (EMagazine)lib.GetItem(3);
            mag.ArchiveIssue();
            decimal fine = lib.ReturnItem(rec.RecordId);
            Console.WriteLine("Returned with fine: " + fine);
            Console.WriteLine("Audiobooks:");
            foreach (Audiobook a in lib.SearchByType<Audiobook>())
            {
                Console.WriteLine("- " + a.Title);
            }
        }
    }
}
