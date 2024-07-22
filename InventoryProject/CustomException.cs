using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message): base(message) { }
    }
}
