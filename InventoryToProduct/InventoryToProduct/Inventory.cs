using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryToProduct
{
    public class Inventory
    {
        public GenericRepository<Product> productRepository = new GenericRepository<Product>();

        public void Add(Product product)
        {
            productRepository.Add(product);
        }
        public void Remove(int pid)
        {
            var r_id = productRepository.products.Find(p => p.Product_Id == pid);
            if(r_id != null)
            {
                productRepository.Remove(r_id);
            }
            else
            {
                throw new ProductNotFoundException("Product Not Found");
            }
        }
        public void Update(int pid , string name , int stock , double price)
        {
            var uid = productRepository.products.Find(p => p.Product_Id == pid);
            if(uid != null)
            {
                uid.Product_Name = name;
                uid.Stock = stock;
                uid.Price = price;
                productRepository.ItemUpdate(uid);
            }
            else
            {
                ProductNotFoundException();
            }
        }
        public double Calculate_Product_Price()
        {
            double total_value = 0;
            foreach (var item in productRepository.products)
            {
                total_value += item.Price * item.Stock;
            }
            return total_value;
        }
        public void ProductNotFoundException()
        {
            throw new ProductNotFoundException("Product not Found");
        }
        public void Search(string name)
        {
            var product_name = productRepository.products.Find(p => p.Product_Name == name);
            if(product_name != null)
            {
                productRepository.Search(product_name);
            }
            else
            {
                ProductNotFoundException();
            }
        }
    }
}
