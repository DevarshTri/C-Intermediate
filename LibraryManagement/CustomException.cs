using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(string message):base(message) { }
    }

    public class BookNotReturnException : Exception
    {
        public BookNotReturnException(string message):base(message) { }
    }
}
