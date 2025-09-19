using System;

namespace LibraNetDemo.Models
{
    public class BorrowRecord
    {
        public int RecordId { get; }
        public int ItemId { get; }
        public int UserId { get; }
        public DateTime BorrowDate { get; }
        public DateTime DueDate { get; }
        public DateTime? ReturnDate { get; private set; }
        public decimal FinePaid { get; private set; }

        public BorrowRecord(int recordId, int itemId, int userId, DateTime borrowDate, DateTime dueDate)
        {
            RecordId = recordId;
            ItemId = itemId;
            UserId = userId;
            BorrowDate = borrowDate;
            DueDate = dueDate;
        }

        public void SetReturn(DateTime returnDate, decimal fine)
        {
            ReturnDate = returnDate;
            FinePaid = fine;
        }

        public override string ToString()
        {
            return string.Format("BorrowRecord{{id={0}, item={1}, user={2}, borrow={3}, due={4}, returned={5}, fine={6}}}", RecordId, ItemId, UserId, BorrowDate, DueDate, ReturnDate, FinePaid);
        }
    }
}
