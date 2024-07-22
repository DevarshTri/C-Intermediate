using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryToUser
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GenericRepository<Book> bookRepository { get; set; }

        public User(int id , string name)
        {
            Id = id;
            Name = name;
            bookRepository = new GenericRepository<Book>();
        }
    }
}
