using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2._0
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(string message): base(message) { }
    }
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message) { }
    }
}
