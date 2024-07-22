using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryToCustomer
{
    public class Product
    {
        public int Product_Id   { get; set; }
        public string Product_Name { get; set; }
        public double Product_Price     { get; set; }
        public int Product_Stock { get; set; }

        public Product(int product_Id, string product_Name, double product_Price, int product_Stock)
        {
            Product_Id = product_Id;
            Product_Name = product_Name;
            Product_Price = product_Price;
            Product_Stock = product_Stock;
        }
    }
}
