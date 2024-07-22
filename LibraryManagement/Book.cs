using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Book
    {
        public int Book_Id { get; set; }
        public string Book_Title { get; set; }
        public string Book_Author { get; set; }
        public double Book_Price { get; set; }

        public bool isAvailable { get; set; }
        public Book(int book_Id, string book_Title, string book_Author, double book_Price)
        {
            Book_Id = book_Id;
            Book_Title = book_Title;
            Book_Author = book_Author;
            Book_Price = book_Price;
            isAvailable = true;
        }
    }
}
