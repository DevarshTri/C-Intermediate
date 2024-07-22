using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryToCustomer
{
    public class Supplier
    {
        public int Supplier_Id { get; set; }
        public string Supplier_Name { get; set; }
        public GenericRepository<Product> ProductRepository { get; set; }

        public Supplier ( int supplier_Id, string supplier_Name)
        {
            Supplier_Id = supplier_Id;
            Supplier_Name = supplier_Name;
            ProductRepository = new GenericRepository<Product>();
        }
    }
}
