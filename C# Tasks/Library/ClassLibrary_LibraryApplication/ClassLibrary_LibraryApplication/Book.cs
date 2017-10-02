using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_LibraryApplication
{
    public struct BookMainProperities
    {
        public String Author;
        public String NameOfBook;
        public bool legendary;
        public BookMainProperities(String Author, String NameOfBook, bool legendary)
        {
            this.Author = Author;
            this.NameOfBook = NameOfBook;
            this.legendary = legendary;
        }
    }


    public class Book
    {
        public BookMainProperities mainProperties { get; private set; }
        public bool IsInLibrary { get; private set; }
        public DateTime DateOfBind { get; private set; }
        public DateTime DateOfUnBind { get; private set; }

        public Book(String Author, String NameOfBook, bool legendary)
        {
            mainProperties = new BookMainProperities(Author, NameOfBook, legendary);
            IsInLibrary = true;
            DateOfBind = new DateTime(1, 1, 1);
            DateOfUnBind = new DateTime(9000, 1, 1);
        }

        private Book() { }

        public void Bind(DateTime currentDate, int daysToUnbind)
        {
            IsInLibrary = false;

            DateOfBind = currentDate.AddDays(0);
            DateOfUnBind = currentDate.AddDays(daysToUnbind);
        }

        public void Bind(DateTime currentDate)
        {
            IsInLibrary = false;

            DateOfBind = currentDate.AddDays(0);
            DateOfUnBind = currentDate.AddDays(7);
        }

        public void Unbind()
        {
            IsInLibrary = true;
            DateOfUnBind = new DateTime(9000, 1, 1);
        }

    }
}
