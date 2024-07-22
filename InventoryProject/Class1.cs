using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject
{
    public class Inventory
    {
        GenericRepository<Product> productRepository = new GenericRepository<Product>();

        public void Add(Product product)
        {
            productRepository.Add(product);
        }

        public void Remove(string name)
        {
            Product p_name = productRepository.Products.Find(p => p.Product_Name.ToLower() == name.ToLower());
            if(p_name != null)
            {
                productRepository.Remove(p_name);
            }
            else
            {
                throw new ProductNotFoundException("Product Not Found");
            }
        }

        public void Update (int id , string name , string category , int quantity , double price)
        {
            Product p_id = productRepository.Products.Find(p =>p.Product_Id == id);
            if(p_id != null)
            {
                p_id.Product_Name = name;
                p_id.Product_Category = category;
                p_id.Product_Quantity = quantity;
                p_id.Product_Price = price;
                productRepository.Update(p_id);
            }
            else
            {
                throw new ProductNotFoundException("Product Not Found");
            }
        }
        public void Total_Price(int id ,string name)
        {
            Product p_id = productRepository.Products.Find(p => p.Product_Id == id);
            if (p_id != null)
            {
                productRepository.Calculate_Price(p_id);
            }
            else
            {
                throw new ProductNotFoundException("Product Not Found");
            }
        }
        public void Search(string name)
        {
            Product p_name = productRepository.Products.Find(p => p.Product_Name.ToLower() == name.ToLower());   
            if(p_name != null)
            {
                productRepository.Search(p_name);
            }
            else
            {
                throw new ProductNotFoundException("Product Not Found");
            }
        }
        public void GetProducts()
        {
            var product = productRepository.GetProducts();
            foreach (var item in product)
            {
                Console.WriteLine($"Name:{item.Product_Name}");
                Console.WriteLine($"Quantity:{item.Product_Quantity}");
                Console.WriteLine($"Price:{item.Product_Price}");
            }
        }
    }
}
