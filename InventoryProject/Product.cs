using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject
{
    public class Product
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Category { get; set; }
        public int Product_Quantity { get; set; }
        public double Product_Price { get; set; }

        public Product(int product_Id, string product_Name, string product_Category, int product_Quantity, double product_Price)
        {
            Product_Id = product_Id;
            Product_Name = product_Name;
            Product_Category = product_Category;
            Product_Quantity = product_Quantity;
            Product_Price = product_Price;
        }
    }
}
