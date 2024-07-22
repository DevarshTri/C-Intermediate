using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2._0
{
    public class LIbrary
    {
        public GenericRepository<Book> bookRepository = new GenericRepository<Book>();

        public void Add(Book book)
        {
            bookRepository.Add(book);
        }
        public void Remove(int R_id)
        {
            var book_id = bookRepository.books.Find(b => b.Book_Id == R_id);
            if(book_id != null)
            {
                bookRepository.Remove(book_id);
            }
            else
            {
                throw new BookNotFoundException("Book Not Found");
            }
        }
        public void Update(int u_id , string u_title , string u_author , double u_price)
        {
            var update_id = bookRepository.books.Find(b => b.Book_Id==u_id);
            if(update_id != null)
            {
                update_id.Book_Title = u_title;
                update_id.Book_Author = u_author;
                update_id.Book_Price = u_price;
                bookRepository.Update(update_id);
            }
            else
            {
                throw new BookNotFoundException("Book Not Found");
            }
        }
        public void DisplayBooks()
        {
            var Books = bookRepository.getBooks();
            if (Books == null)
            {
                foreach (var Book in Books)
                {
                    Console.WriteLine($"Title : {Book.Book_Title}");
                    Console.WriteLine($"Author : {Book.Book_Author}");
                    Console.WriteLine($"Price : {Book.Book_Price}");
                }
            }
            else
            {
                Console.WriteLine("Library is Empty");
            }
        }
        public void Search(string title)
        {
            var book_title = bookRepository.books.Find(b => b.Book_Title.ToLower() == title.ToLower());
            if (book_title != null)
            {
                bookRepository.Search(book_title);
            }
            else
            {
                throw new BookNotFoundException("Book Not Found");
            }
        }
    }
}
