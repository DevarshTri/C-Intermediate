using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Class1 
    {
        GenericRepository<Book> bookRepository = new GenericRepository<Book>();

        public void Add(Book book)
        {
            bookRepository.Add(book);
        }

        public void Remove(int id)
        {
            Book bookid = bookRepository.items.Find(x => x.Book_Id == id);
            if (bookid != null)
            {
                bookRepository.Remove(bookid);
            }
            else
            {
                throw new BookNotFoundException("Book Not Found");
            }
        }

        public void Update(int id, string newTitle, string newAuthor, double newPrice)
        {
            Book UBook = bookRepository.items.Find(x => x.Book_Id == id);
            if (UBook != null)
            {
                UBook.Book_Id = id;
                UBook.Book_Title = newTitle;
                UBook.Book_Author = newAuthor;
                UBook.Book_Price = newPrice;
                bookRepository.Update(UBook);
            }
            else
            {
                throw new BookNotFoundException("Book Not Found");
            }
        }
        public void Borrow_Book(int id)
        {
            Book bookid = bookRepository.items.Find(b=> b.Book_Id == id);
            if(bookid != null)
            {
                bookRepository.Borrow_Book(bookid);
                Console.WriteLine($"Title - {bookid.Book_Title}");
            }
            else
            {
                throw new BookNotFoundException("Book not found");
            }
        }

        public void Return_Book(int id)
        {
            Book R_id = bookRepository.items.Find(r =>r.Book_Id == id);
            if(R_id != null)
            {
                bookRepository.Return_book(R_id);
                Console.WriteLine($"Title - {R_id.Book_Title}");
            }
            else
            {
                throw new BookNotReturnException("Book not Borrowed Yet");
            }
        }
        public void DisplayAll()
        {
            var books = bookRepository.GetBooks();
            foreach (var item in books)
            {
                Console.WriteLine($"Title : {item.Book_Title}");
                Console.WriteLine($"Price : {item.Book_Price}");
            }
        }
        public void DisplayAvailableBooks()
        {
            var books = bookRepository.GetBooks();
            foreach (var item in books)
            {
                if (item.isAvailable)
                {
                    Console.WriteLine($"Title : {item.Book_Title}");
                    Console.WriteLine($"Price : {item.Book_Price}");
                }
            }
        }

        public void Search_Book(string title)
        {
            Book book_title = bookRepository.items.Find(s=> s.Book_Title == title);
            if(book_title != null )
            {
                bookRepository.Search_Book(book_title);
            }
            else
            {
                Console.WriteLine("Book Not Found");
            }
        }
    }
}
