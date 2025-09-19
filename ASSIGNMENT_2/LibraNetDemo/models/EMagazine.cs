using System;

namespace LibraNetDemo.Models
{
    public class EMagazine : LibraryItem
    {
        public int IssueNumber { get; }
        private bool archived = false;

        public EMagazine(int id, string title, string author, int issueNumber)
            : base(id, title, author)
        {
            IssueNumber = issueNumber;
        }

        public void ArchiveIssue()
        {
            if (archived)
            {
                Console.WriteLine("Issue {0} already archived.", IssueNumber);
            }
            else
            {
                archived = true;
                Console.WriteLine("Archived issue {0} of {1}", IssueNumber, Title);
            }
        }
    }
}
