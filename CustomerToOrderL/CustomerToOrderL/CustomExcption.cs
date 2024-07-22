using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerToOrderL
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(string message): base(message) { }
    }
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string message): base(message) { }
    }
}
