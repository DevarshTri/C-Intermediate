using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject
{
    public delegate void InventoryHandler();
    public class GenericRepository<T> where T : Product
    {
        public event InventoryHandler InventoryAdded;
        public event InventoryHandler InventoryRemoved;
        public event InventoryHandler InventoryUpdated;

        public GenericRepository() 
        {
            this.InventoryAdded += new InventoryHandler(OnInventoryAdd);
            this.InventoryRemoved += new InventoryHandler(OnInventoryRemove);
            this.InventoryUpdated += new InventoryHandler(OnInventoryUpdated);
        }
        public List<T> Products = new List<T>();

        public void Add(T product)
        {
            Products.Add(product);
            InventoryAdded?.Invoke();
        }

        public void Remove(T product)
        {
            if(Products.Contains(product))
            {
                Products.Remove(product);
                InventoryRemoved?.Invoke();
            }
        }

        public void Update(T product)
        {
            var U_id = Products.FindIndex(p => p.Product_Id == product.Product_Id);
            if(U_id != -1)
            {
                Products[U_id] = product;
                InventoryUpdated?.Invoke();
            }
        }

        public void Calculate_Price(T product)
        {
            double price = 0;
            if (Products.Contains(product))
            {
                price = product.Product_Quantity * product.Product_Price;
                Console.WriteLine("Total Price Of Product You Add:");
                Console.WriteLine($"{product.Product_Name} : {price}");
            }
        }

        public void Search(T product)
        {
            var s_id = Products.Find(s=> s.Product_Id==product.Product_Id);
            if(s_id != null)
            {
                Console.WriteLine("Product Found");
                Console.WriteLine($"{s_id.Product_Name}");
            }
        }

        public List<T> GetProducts()
        {
            return Products;
        }

        public void OnInventoryAdd()
        {
            Console.WriteLine("Product Added");
        }
        public void OnInventoryRemove()
        {
            Console.WriteLine("Product Removed");
        }
        public void OnInventoryUpdated()
        {
            Console.WriteLine("Product Updated");
        }
    }
}
