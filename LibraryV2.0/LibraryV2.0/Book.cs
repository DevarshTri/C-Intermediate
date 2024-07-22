using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2._0
{
    public class Book
    {
        public int Book_Id { get; set; }
        public string Book_Title { get; set; }
        public string Book_Author { get; set; }
        public double Book_Price  { get; set; }

        public Book(int id , string title, string author, double price)
        {
            Book_Id = id;
            Book_Title = title;
            Book_Author = author;
            Book_Price = price;
        }
    }
}
