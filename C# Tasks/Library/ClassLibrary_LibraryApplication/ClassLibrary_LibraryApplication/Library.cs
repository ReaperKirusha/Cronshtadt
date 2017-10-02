using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_LibraryApplication
{
    public class Library
    {
        Dictionary<Book, User> BooksOfLibrary;
        List<User> UsersOfLibrary;

        public Library()
        {
            BooksOfLibrary = new Dictionary<Book, User>();
            UsersOfLibrary = new List<User>();
        }

        public int AddNewbook(String Author, String NameOfBook, bool legendary)
        {
            BooksOfLibrary.Add(new Book(Author, NameOfBook, legendary), null);
            return 1;
        }
        public int AddNewbook(Book objBook)
        {
            BooksOfLibrary.Add(objBook, null);
            return 1;
        }

        public int addNewUser(string NameOfUser, long PhoneNumber)
        {
            if (FindUSerByName(NameOfUser) != null)
            {
                return 0;
            }

            UsersOfLibrary.Add(new User(NameOfUser, PhoneNumber));
            return 1;

        }
        public int addNewUser(User objUser)
        {
            if (FindUSerByName(objUser.NameOfUser) != null)
            {
                return 0;
            }

            UsersOfLibrary.Add(objUser);
            return 1;
        }

        public List<User> ShowUsers()
        {
            return UsersOfLibrary;
        }

        public Dictionary<Book, User> ShowBooksOnHands()
        {
            Dictionary<Book, User> BooksOnHands = new Dictionary<Book, User>();
            foreach (KeyValuePair<Book, User> kvp in BooksOfLibrary)
            {
                if (kvp.Value != null)
                {
                    BooksOnHands.Add(kvp.Key, kvp.Value);
                }
            }
            //if (BooksOnHands.Count == 0)
                //return null;

            return BooksOnHands;
        }

        public Dictionary<Book, User> ShowBooksInLibrary()
        {
            Dictionary<Book, User> BooksInLibrarys = new Dictionary<Book, User>();
            foreach (KeyValuePair<Book, User> kvp in BooksOfLibrary)
            {
                if (kvp.Value == null)
                {
                    BooksInLibrarys.Add(kvp.Key, kvp.Value);
                }

            }
            if (BooksInLibrarys.Count == 0)
                return null;

            return BooksInLibrarys;
        }

        public Dictionary<Book, User> ShowBooksOfUser(User objUser)
        {
            Dictionary<Book, User> BooksOfUser = new Dictionary<Book, User>();
            foreach (KeyValuePair<Book, User> kvp in BooksOfLibrary)
            {
                if (kvp.Value == objUser)
                {
                    BooksOfUser.Add(kvp.Key, kvp.Value);
                }
            }

            //if (BooksOfUser.Count == 0)
               // return null;

            return BooksOfUser;
        }

        public Book FindBookByAuthorName(String Author, String NameOfBook)
        {
            foreach (KeyValuePair<Book, User> kvp in BooksOfLibrary)
            {
                if ((kvp.Key.mainProperties.Author == Author)
                    && (kvp.Key.mainProperties.NameOfBook == NameOfBook))
                {
                    return kvp.Key;
                }
            }

            return null;
        }

        public User FindUSerByName(String NameOfUSer)
        {
            foreach (User objUser in UsersOfLibrary)
            {
                if (objUser.NameOfUser == NameOfUSer)
                {
                    return objUser;
                }
            }
            return null;
        }

        public int DoesUserHasDebts(User objUser, DateTime currentTime)
        {
            foreach (KeyValuePair<Book, User> kvp in BooksOfLibrary)
            {
                if (kvp.Value == objUser)
                {
                    if (kvp.Key.DateOfUnBind < currentTime)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        public int BindBookToUser(Book objBook, User objUser, DateTime currentTime)
        {
            if (DoesUserHasDebts(objUser, currentTime) == 1)
            {
                return -1;
            }

            if (objUser.NumberOfBooks > (objUser.NumberOfBooksAllowed - 1))
            {
                return 0;
            }

            if (!UsersOfLibrary.Contains(objUser))
            {
                return -2;
            }
            objBook.Bind(currentTime);
            BooksOfLibrary.Remove(objBook);
            BooksOfLibrary.Add(objBook, objUser);
            
            return 1;
        }

        public int UnBindBookToUser(Book objBook, User objUser)
        {
            if (!UsersOfLibrary.Contains(objUser))
            {
                return 0;
            }
            KeyValuePair<Book, User> kvp = new KeyValuePair<Book, User>(objBook, objUser);
            if (!BooksOfLibrary.Contains(kvp))
            {
                return -1;
            }

            BooksOfLibrary.Remove(objBook);
            BooksOfLibrary.Add(objBook, null);
            objBook.Unbind();
            return 1;
        }

    }
}

