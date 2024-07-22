using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InventoryToProduct
{
    public delegate void ProductHandler(object sender ,EventArgs eventArgs);
    public delegate void ProductUpdate();
    public class GenericRepository<T> where T : Product
    {
        public event ProductHandler ProductAdded;
        public event ProductHandler ProductDeleted;
        public event ProductUpdate ProductUpdated;

        public GenericRepository()
        {
            this.ProductAdded += OnItemAdd;
            this.ProductDeleted += OnItemDeleted;
            this.ProductUpdated += OnItemUpdate;
        }
        public List<T> products = new List<T>();

        public void Add(T product)
        {
            products.Add(product);
            ItemAdd(product);
            
        }
        public void Remove(T product)
        {
            if (products.Contains(product))
            {
                products.Remove(product);
                ItemDelete(product);
            }
        }
        public void Search(T product)
        {
            var product_name = products.Find(p => p.Product_Name == product.Product_Name);
            if (product_name != null)
            {
                Console.WriteLine($"Name : {product_name.Product_Name} found");
            }
        }
        public void OnItemAdd(object sender , EventArgs eventArgs)
        {
            Console.WriteLine("Product Added");
        }
        public void ItemAdd(T product)
        {
            ProductAdded?.Invoke(this, product);
        }
        public void OnItemDeleted(object sender , EventArgs eventArgs)
        {
            Console.WriteLine("Product Deleted");
        }
        public void ItemDelete(T product)
        {
            ProductDeleted?.Invoke(this, product);
        }
        public void ItemUpdate(T product)
        {
            ProductUpdated?.Invoke();
        }
        public void OnItemUpdate()
        {
            Console.WriteLine("Product Updated");
        }
    }
}
