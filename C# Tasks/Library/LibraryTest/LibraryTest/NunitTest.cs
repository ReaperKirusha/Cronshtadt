using System;
using System.Linq;
using NUnit.Framework;
using ClassLibrary_LibraryApplication;

namespace LibraryTest
{
    [TestFixture]
    public class NunitTest
    {
        [SetUp]
        public void SetUpForLivrary()
        {
            new NUnit.Framework.Internal.TestExecutionContext().EstablishExecutionEnvironment();
        }      

        [Test]
        public void addNewBookTest()
        {           
            Library NewLibrary = new Library();

            Book NewBook = new Book("Автор", "Книга", true);

            NewLibrary.addNewUser("Вася", 9090);
            NewLibrary.AddNewbook("Автор2", "Книга2", true);
            NewLibrary.AddNewbook(NewBook);
            
            Assert.AreEqual(NewLibrary.ShowBooksInLibrary().Count, 2);
            Assert.False(!NewLibrary.ShowBooksInLibrary().Keys.Contains(NewBook));
        }

        [Test]
        public void findBookTest()
        {

            Library NewLibrary = new Library();
            Book NewBook = new Book("Автор", "Книга", true);

            NewLibrary.AddNewbook("Автор2", "Книга2", true);
            NewLibrary.AddNewbook(NewBook);

            NewLibrary.FindBookByAuthorName("Автор", "Книга");

            Assert.AreEqual(NewLibrary.FindBookByAuthorName("Автор", "Книга"), NewBook);
            Assert.False(!NewLibrary.ShowBooksInLibrary().Keys.Contains(NewLibrary.FindBookByAuthorName("Автор", "Книга")));
        }

        [Test]
        public void findUserTest()
        {
            Library NewLibrary = new Library();

            Book NewBook = new Book("Автор", "Книга", true);

            User Kostya = new User("Костя", 9090);

            NewLibrary.addNewUser("Вася", 9090);
            NewLibrary.addNewUser(Kostya);
            NewLibrary.AddNewbook("Автор2", "Книга2", true);
            NewLibrary.AddNewbook(NewBook);

            Kostya.BindBook();

            Assert.AreEqual(NewLibrary.FindUSerByName("Костя"), Kostya);
        }

        [Test]
        public void BindBookToUserTest()
        {
            DateTime currentTime = new DateTime(2017, 05, 1);
            Library NewLibrary = new Library();

            Book NewBook = new Book("Автор", "Книга", true);

            NewLibrary.addNewUser("Вася", 9090);
            NewLibrary.AddNewbook("Автор2", "Книга2", true);
            NewLibrary.AddNewbook(NewBook);

            User vasya = NewLibrary.FindUSerByName("Вася");
            Book Author = NewLibrary.FindBookByAuthorName("Автор", "Книга");

            Assert.AreEqual(NewLibrary.BindBookToUser(NewLibrary.FindBookByAuthorName("Автор", "Книга"), NewLibrary.FindUSerByName("Вася"), currentTime), 1);

            Assert.AreEqual(NewLibrary.ShowBooksOfUser(NewLibrary.FindUSerByName("Вася")).Count(), 1);

            Assert.False(!NewLibrary.ShowBooksOnHands().Values.Contains(vasya));

            Assert.False(!NewLibrary.ShowUsers().Contains(vasya));

            DateTime newDate = currentTime.AddDays(0);
            currentTime = currentTime.AddDays(8);

            Assert.AreEqual(NewLibrary.ShowBooksOfUser(NewLibrary.FindUSerByName("Вася")).ElementAt(0).Key.DateOfBind, newDate);

            Assert.AreEqual(NewLibrary.ShowBooksOfUser(NewLibrary.FindUSerByName("Вася")).ElementAt(0).Key.DateOfUnBind, newDate.AddDays(7));
        }

        [Test]
        public void ShowBooksInLibraryTest()
        {
            DateTime currentTime = new DateTime(2017, 05, 1);
            Library NewLibrary = new Library();

            Book NewBook = new Book("Автор", "Книга", true);

            NewLibrary.addNewUser("Вася", 9090);
            NewLibrary.AddNewbook("Автор2", "Книга2", true);
            NewLibrary.AddNewbook(NewBook);
        }

        [Test]
        public void ShowBooksOfUserTest()
        {
        }

        [Test]
        public void ShowBooksOnHandsTest()
        {
        }

        [Test]
        public void DoesUserHasDebtsTest()
        {
            new NUnit.Framework.Internal.TestExecutionContext().EstablishExecutionEnvironment();
            DateTime currentTime = new DateTime(2017, 05, 1);
            Library NewLibrary = new Library();

            Book NewBook = new Book("Автор", "Книга", true);

            NewLibrary.addNewUser("Вася", 9090);
            NewLibrary.AddNewbook("Автор2", "Книга2", true);
            NewLibrary.AddNewbook(NewBook);

            User vasya = NewLibrary.FindUSerByName("Вася");
            Book Author = NewLibrary.FindBookByAuthorName("Автор", "Книга");

            Assert.AreEqual(NewLibrary.DoesUserHasDebts(NewLibrary.FindUSerByName("Вася"), currentTime),0);

            Assert.AreEqual(NewLibrary.BindBookToUser(NewLibrary.FindBookByAuthorName("Автор", "Книга"),
                NewLibrary.FindUSerByName("Вася"), currentTime),1);

            Assert.AreEqual(NewLibrary.DoesUserHasDebts(NewLibrary.FindUSerByName("Вася"),currentTime), 0);
            currentTime = currentTime.AddDays(8);

            Assert.AreEqual(NewLibrary.DoesUserHasDebts(NewLibrary.FindUSerByName("Вася"), currentTime), 1);
        }

        [Test]
        public void UnBindBookTest()
        {
            DateTime currentTime = new DateTime(2017, 05, 1);
            Library NewLibrary = new Library();

            Book NewBook = new Book("Автор", "Книга", true);

            NewLibrary.addNewUser("Вася", 9090);
            NewLibrary.AddNewbook("Автор2", "Книга2", true);
            NewLibrary.AddNewbook(NewBook);

            User vasya = NewLibrary.FindUSerByName("Вася");
            Book Author = NewLibrary.FindBookByAuthorName("Автор", "Книга");

            NewLibrary.BindBookToUser(NewLibrary.FindBookByAuthorName("Автор", "Книга"), 
                NewLibrary.FindUSerByName("Вася"), currentTime);

            Assert.AreEqual(NewLibrary.UnBindBookToUser(NewLibrary.FindBookByAuthorName("Автор", "Книга"), 
                NewLibrary.FindUSerByName("Вася")), 1);
            
            Assert.AreEqual(NewLibrary.ShowBooksOfUser(NewLibrary.FindUSerByName("Вася")).Count(), 0);

            Assert.False(NewLibrary.ShowBooksOnHands().Values.Contains(vasya));

            Assert.False(!NewLibrary.ShowUsers().Contains(vasya));
        }

    }
}
