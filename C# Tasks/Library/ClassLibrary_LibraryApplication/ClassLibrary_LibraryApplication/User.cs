using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_LibraryApplication
{
    public class User
    {
        public String NameOfUser { get; private set; }
        public long PhoneNumber { get; set; }
        public int NumberOfBooks { get; private set; }
        public int NumberOfBooksAllowed { get; private set; }

        private User() { }
        public User(String NameOfUser, long PhoneNumber)
        {
            this.NameOfUser = NameOfUser;
            this.PhoneNumber = PhoneNumber;
            this.NumberOfBooks = 0;
            NumberOfBooksAllowed = 5;
        }

        public void BindBook()
        {
            NumberOfBooks++;
        }
    }
}
