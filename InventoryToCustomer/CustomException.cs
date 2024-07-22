using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryToCustomer
{
    public class ProductNotFoundException :  Exception
    {
        public ProductNotFoundException(string message):base(message) { }
    }
    public class SupplierNotFoundException : Exception
    {
        public SupplierNotFoundException (string message):base(message) { }
    }
}
