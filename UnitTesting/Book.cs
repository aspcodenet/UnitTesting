using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class Book
    {
        public string Isbn { get; }
        public string Author { get;  }
        public string Title { get; }
        public int Count { get; protected set; }
        public int Borrowed => borrowers.Count;

        public bool Borrow(string borrower)
        {
            if (borrowers.Count() >= Count) return false;
            borrowers.Add(borrower);
            return true;
        }
        public bool IsBorrower(string borrower)
        {
            return borrowers.Contains(borrower);
        }

        public void BuyNewEx(int count)
        {
            if(count < 1) throw new ArgumentException("count >1 please");
            Count += count;
        }

        private List<string> borrowers = new List<string>();

        public int Available => Count - Borrowed;

        public Book(string isbn, string author, string title)
        {
            Isbn = isbn;
            Author = author;
            Count = 0;
        }
    }
}
