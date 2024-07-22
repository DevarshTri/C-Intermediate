using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public delegate void LibraryChangedHandler();
    public class GenericRepository<T> where T : Book
    {
        public event LibraryChangedHandler LibraryAdded;
        public event LibraryChangedHandler LibraryRemoved;
        public event LibraryChangedHandler LibraryUpdated;
        public event LibraryChangedHandler LibraryBorrowed;
        public event LibraryChangedHandler LibraryReturned;

        public GenericRepository()
        {
            this.LibraryAdded += new LibraryChangedHandler(ItemAdd);
            this.LibraryRemoved += new LibraryChangedHandler(ItemRemove);
            this.LibraryUpdated += new LibraryChangedHandler(ItemUpdate);
            this.LibraryBorrowed += new LibraryChangedHandler(OnBorrow);
            this.LibraryReturned += new LibraryChangedHandler(OnReturn);
        }

        public List<T> items = new List<T> ();

        public void Add(T item)
        {
            items.Add (item);
            OnItemAdded(item);
        }

        public void Remove(T item)
        {
            if(items.Contains(item))
            {
                items.Remove(item);
                OnItemRemove(item);
            }
            else
            {
                throw new BookNotFoundException("Book Not Found");
            }
        }
        public void Update(T item)
        {
            var book = items.FindIndex(d => d.Book_Id == item.Book_Id);
            if(book != -1)
            {
                items[book] = item;
                OnItemUpdated(item);
            }
            else
            {
                throw new BookNotFoundException("Book Not Found");
            }
        }
        public List<T> GetBooks()
        {
            return items;
        }
        public void Borrow_Book(T item)
        {
            if (item.isAvailable)
            {
                item.isAvailable = false;
                LibraryBorrowed?.Invoke();
            }
            else
            {
                Console.WriteLine("Book Is Available for Borrowed");
            }
        }

        public void Return_book(T item)
        {
            if (!item.isAvailable)
            {
                item.isAvailable= true;
                LibraryReturned?.Invoke();
            }
            else
            {
                throw new BookNotReturnException("Book Not Borrowed Yet");
            }
        }

        public void Search_Book(T item)
        {
            var book_search = items.Find(s => s.Book_Title == item.Book_Title);
            if(book_search != null)
            {
                Console.WriteLine($"Book Found : Title - {book_search.Book_Title}");
            }
            else
            {
                Console.WriteLine("Book Not Found");
            }
        }
       
        public void ItemAdd()
        {
            Console.WriteLine("Library Changed , Item Added");
        }
        public void ItemRemove()
        {
            Console.WriteLine("Library Changed , Item Removed");
        }
        public void ItemUpdate()
        {
            Console.WriteLine("Library Changed , Item Updated");
        }
        public void OnItemAdded(T item)
        {
            LibraryAdded?.Invoke();
        }
        public void OnItemRemove(T item)
        {
            LibraryRemoved?.Invoke();
        }
        public void OnItemUpdated(T item)
        {
            LibraryUpdated?.Invoke();
        }

        public void OnBorrow()
        {
            Console.WriteLine("Library Changed , Item Borrowed");
        }
        public void OnReturn()
        {
            Console.WriteLine("Library Changed , Item Returned");
        }
    }
}
