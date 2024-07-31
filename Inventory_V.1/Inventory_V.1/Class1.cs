using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_V._1
{
    public class Inventory
    {
        public GenericRepository<Product> ProductRepository = new GenericRepository<Product>();

        public void Add(Product product)
        {
            ProductRepository.Add(product);
        }
        public void Remove(int product_id)
        {
            var productId = ProductRepository.Products.Find(p => p.Product_Id == product_id);
            if (productId != null)
            {
                ProductRepository.Remove(productId);
            }
            else
            {
                throw new ProductNotFoundException("Product Not Found");
            }
        }
        public void Update(int product_id, string product_name, double product_price, int newStock)
        {
            var products = ProductRepository.Products.Find(p => p.Product_Id == product_id);
            if (products != null)
            {
                products.Product_Name = product_name;
                products.Product_Price = product_price;
                products.Product_Stock = newStock;
                ProductRepository.Update(products);
            }
            else
            {
                throw new ProductNotFoundException("Product Not Found");
            }
        }
        public void Search(string product_name)
        {
            var productname = ProductRepository.Products.Find(p => p.Product_Name.ToLower() == product_name.ToLower());
            if (productname != null)
            {
                ProductRepository.Search(productname);
            }
            else
            {
                throw new ProductNotFoundException("Product Not Found");
            }
        }
        public void Display_Products()
        {
            var products = ProductRepository.getProducts();
            foreach (var item in products)
            {
                Console.WriteLine($"Name : {item.Product_Name}");
                Console.WriteLine($"Price : {item.Product_Price}");
                Console.WriteLine($"Stock : {item.Product_Stock}");
            }
        }
        public void Total_Stock_Price(int product_id)
        {
            var productid = ProductRepository.Products.Find(p => p.Product_Id == product_id);
            if(productid != null)
            {
                ProductRepository.TotalStockPrice(productid);
            }
            else
            {
                throw new ProductNotFoundException("Product Not Found");
            }
        }
    }
}
