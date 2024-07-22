using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryToUser
{
    public delegate void LibraryHandler();
    public class GenericRepository<T> where T : Book
    {
        public event LibraryHandler ItemAdd;
        public event LibraryHandler ItemRemove;
        public event LibraryHandler ItemUpdate;

        public List<T> books = new List<T>();

        public GenericRepository()
        {
            this.ItemAdd += new LibraryHandler(OnItemAdd);
            this.ItemRemove += new LibraryHandler(OnItemRemove);
            this.ItemUpdate += new LibraryHandler(OnItemUpdate);
        }

        public void Add(T book)
        {
            books.Add(book);
            ItemAdd?.Invoke();
        }
        public void Remove(T book)
        {
            if(books.Contains(book))
            {
                books.Remove(book);
                ItemRemove?.Invoke();
            }
        }
        public void Update(T book)
        {
            var b_id = books.FindIndex(b => b.Book_Id == book.Book_Id);
            if(b_id != -1)
            {
                books[b_id] = book; 
                ItemUpdate?.Invoke();
            }
        }
        public List<T> GetBooks()
        {
            return books;
        }
        public void OnItemAdd()
        {
            Console.WriteLine("Book Added");
        }
        public void OnItemRemove()
        {
            Console.WriteLine("Book Removed");
        }
        public void OnItemUpdate()
        {
            Console.WriteLine("Book Updated");
        }
    }
}
