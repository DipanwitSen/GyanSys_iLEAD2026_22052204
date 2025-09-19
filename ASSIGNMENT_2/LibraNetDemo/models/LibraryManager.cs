using System;
using System.Collections.Generic;

namespace LibraNetDemo.Models
{
    public class LibraryManager
    {
        private readonly Dictionary<int, LibraryItem> items = new Dictionary<int, LibraryItem>();
        private readonly Dictionary<int, BorrowRecord> borrowRecords = new Dictionary<int, BorrowRecord>();
        private readonly Dictionary<int, decimal> finesByRecord = new Dictionary<int, decimal>();
        private int nextRecordId = 1;
        private readonly decimal finePerDay;

        public LibraryManager(decimal finePerDay)
        {
            this.finePerDay = finePerDay;
        }

        public decimal FinePerDay => finePerDay;

        public void AddItem(LibraryItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (items.ContainsKey(item.Id)) throw new InvalidOperationException("Item id already exists");
            items[item.Id] = item;
        }

        public LibraryItem GetItem(int id)
        {
            if (!items.TryGetValue(id, out LibraryItem it))
                throw new KeyNotFoundException("Item not found: " + id);
            return it;
        }

        public BorrowRecord BorrowItem(int itemId, int userId, string durationStr)
        {
            LibraryItem item = GetItem(itemId);
            if (!item.IsAvailable) throw new InvalidOperationException("Item not available: " + itemId);

            TimeSpan dur = DurationParser.Parse(durationStr);
            DateTime now = DateTime.Now;
            DateTime due = now.Add(dur);

            item.MarkBorrowed();

            int rid = nextRecordId++;
            BorrowRecord rec = new BorrowRecord(rid, itemId, userId, now, due);
            borrowRecords[rid] = rec;
            return rec;
        }

        public decimal ReturnItem(int recordId)
        {
            if (!borrowRecords.TryGetValue(recordId, out BorrowRecord rec))
                throw new KeyNotFoundException("Borrow record not found: " + recordId);

            if (rec.ReturnDate.HasValue)
                throw new InvalidOperationException("Already returned: " + recordId);

            DateTime now = DateTime.Now;
            decimal fine = CalculateFine(rec.DueDate, now, finePerDay);

            rec.SetReturn(now, fine);

            if (items.TryGetValue(rec.ItemId, out LibraryItem item))
                item.MarkReturned();

            if (fine > 0m) finesByRecord[recordId] = fine;

            return fine;
        }

        public static decimal CalculateFine(DateTime due, DateTime returned, decimal finePerDay)
        {
            if (returned <= due) return 0m;

            int daysLate = (returned.Date - due.Date).Days; 
            decimal fine = finePerDay * daysLate;
            return Math.Round(fine, 2);
        }


        public List<T> SearchByType<T>() where T : LibraryItem
        {
            List<T> list = new List<T>();
            foreach (LibraryItem it in items.Values)
            {
                if (it is T typed) list.Add(typed);
            }
            return list;
        }

        public Dictionary<int, decimal> GetFinesByRecord()
        {
            return new Dictionary<int, decimal>(finesByRecord);
        }
    }
}
