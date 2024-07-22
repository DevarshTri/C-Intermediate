using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryToProduct
{
    public class Product : EventArgs
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        public Product(int product_Id, string product_Name, int stock, double price)
        {
            Product_Id = product_Id;
            Product_Name = product_Name;
            Stock = stock;
            Price = price;
        }

        public void UpdateStock(int newStock)
        {
            if(newStock < 0)
            {
                throw new ArgumentException("Stock cannot be negative");
            }
            Stock = newStock;
            Console.WriteLine("Stock Updated");
        }
    }
}
