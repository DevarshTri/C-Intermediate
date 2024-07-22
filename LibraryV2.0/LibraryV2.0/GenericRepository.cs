using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2._0
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
        public void Add(T item)
        {
            books.Add(item);
            ItemAdded(item);
        }
        public void Remove(T item)
        {
            if(books.Contains(item))
            {
                books.Remove(item);
                ItemRemoved(item);
            }
        }
        public void Update(T item)
        {
            var book_index = books.FindIndex(b => b.Book_Id == item.Book_Id);
            if(book_index != -1)
            {
                books[book_index] = item;
                ItemUpdate?.Invoke();
            }
        }
        public void Search(T item)
        {
            var book_name = books.Find(b => b.Book_Title.ToLower() == item.Book_Title.ToLower());
            if(book_name != null)
            {
                Console.WriteLine($"Book Found : {book_name.Book_Title}");
            }
        }
        public List<T> getBooks()
        {
            return books;
        }
        public void ItemAdded(T item)
        {
            ItemAdd?.Invoke();
        }
        public void OnItemAdd()
        {
            Console.WriteLine("Book Added");
        }
        public void OnItemRemove()
        {
            Console.WriteLine("Book Removed");
        }
        public void ItemRemoved(T item)
        {
            ItemRemove?.Invoke();
        }
        public void OnItemUpdate()
        {
            Console.WriteLine("Book Updated");
        }
    }
}
