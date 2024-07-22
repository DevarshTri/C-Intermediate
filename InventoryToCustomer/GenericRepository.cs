using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryToCustomer
{
    public delegate void InventoryEvent();
    public class GenericRepository<T> where T : Product
    {
        public event InventoryEvent InventoryAdd;
        public event InventoryEvent InventoryUpdate;
        public event InventoryEvent InventoryDelete;

        public GenericRepository()
        {
            this.InventoryAdd += new InventoryEvent(OnInventoryAdd);
            this.InventoryUpdate += new InventoryEvent(OnInventoryUpdate);
            this.InventoryDelete += new InventoryEvent(OnIventoryRemove);
        }
        
        public List<T> items = new List<T>();


        public void Add(T item)
        {
            items.Add(item);
            InventoryAdd?.Invoke();
          // InventoryDelete?.Invoke();
            
        }
        public void Remove(T item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                Console.WriteLine("Removed");
                InventoryDelete?.Invoke();
            }
        }
        public void Update(T item)
        {
            var product_index = items.FindIndex(p => p.Product_Id == item.Product_Id);
            if(product_index != -1)
            {
                items[product_index] = item;
                InventoryUpdate?.Invoke();
            }
            else
            {
                throw new ProductNotFoundException("Product Not Found");
            }
        }
        public List<T> GetProducts()
        {
            return items;
        }
        public void Search(string P_name)
        {
            var product_name = items.Find(p => p.Product_Name.ToLower() == P_name.ToLower());
            if(product_name != null)
            {
                Console.WriteLine("Product Found");
            }
        }
        public void Highest_Stock()
        {
            var max_stock = items[0].Product_Stock;

            for(int i = 0; i< items.Count; i++)
            {
                if (items[i].Product_Stock > max_stock)
                {
                    //items[i].Product_Stock = max_stock;
                    max_stock = items[i].Product_Stock;
                    
                    Console.WriteLine($"Name:{items[i].Product_Name}");
                    Console.WriteLine($"Stock:{items[i].Product_Stock}");
                }
            }
            //var products = items.OrderByDescending(p => p.Product_Stock);
            //foreach(var product in products)
            //{
            //    Console.WriteLine($"Name:{product.Product_Name}");
            //}
        }
        public void Stock_item(int stock)
        {
            var products = items.Where(p => p.Product_Stock == stock).ToList();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Product_Name}");
            }
        }
            
        public void OnInventoryAdd()
        {
            Console.WriteLine("------------- Product Added ----------");
        }        
        public void OnInventoryUpdate()
        {
            Console.WriteLine("------------- Product Updated ----------");
        }
        public void OnIventoryRemove()
        {
            Console.WriteLine("---------- Product Removed ------------");
        }
    }
}
