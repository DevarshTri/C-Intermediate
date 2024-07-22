using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryToUser
{
    public class Library
    {
        public List<User> users = new List<User>();
        public List<Book> books = new List<Book>();
        public void Add(User user)
        {
            users.Add(user);
            Console.WriteLine("Added");
        }
        public void Remove(int userId)
        {
            var u_id = users.Find(u => u.Id == userId);
            if (u_id != null)
            {
                users.Remove(u_id);
            }
            else
            {
                throw new UserNotFoundException("User Not Found");
            }
        }
        public void Update(int userId, string name)
        {
            var usr_id = users.Find(usr => usr.Id == userId);
            if (usr_id != null)
            {
                usr_id.Id = usr_id.Id;
                usr_id.Name = name;
            }
            else
            {
                throw new UserNotFoundException("User Not Found");
            }
        }
        public void AddBook(int userId, Book book)
        {
            User user = users.Find(u => u.Id == userId);
            if (user != null)
            {
                user.bookRepository.Add(book);
            }

        }
        public void RemoveBook(int userId, int bookId)
        {
            User user = users.Find(u => u.Id == userId);
            Book book_id = user.bookRepository.books.Find(b => b.Book_Id == bookId);

            if (book_id != null && user != null)
            {
                user.bookRepository.Remove(book_id);
            }
            else
            {
                throw new BookNotFoundException("Book Not Found");
            }
        }
        public void UpdateBook(int userId, int bookId, string title, string author, double price)
        {
            User user = users.Find(u => u.Id == userId);
            Book book_id = user.bookRepository.books.Find(b => b.Book_Id == bookId);

            if (book_id != null && user != null)
            {
                book_id.Book_Title = title;
                book_id.Book_Author = author;
                book_id.Book_Price = price;
                user.bookRepository.Update(book_id);
            }
            else
            {
                throw new BookNotFoundException("Book Not Found");
            }
        }
        public void DisplayAllUsers()
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Name:{user.Name}");
            }
        }
        public void DisplayBooks(int userId)
        {

            User user = users.Find(u => u.Id == userId);

            if (user == null)
            {
                Console.WriteLine("User not found.");
            }
            else if (user.bookRepository == null)
            {
                Console.WriteLine("Book repository not initialized.");
            }
            else
            {
                List<Book> books = user.bookRepository.GetBooks();

                if (books == null || books.Count == 0)
                {
                    Console.WriteLine("No books found for this user.");
                }
                else
                {
                    foreach (Book book in books)
                    {
                        Console.WriteLine(book.Book_Title);
                    }
                }
            }

        }
        public void DisplayAllBooks()
        {
            foreach (var user in users)
            {
                var books = user.bookRepository.GetBooks();
                foreach (var item in books)
                {
                    Console.WriteLine(item.Book_Title);
                }
            }
        }

    }
}

