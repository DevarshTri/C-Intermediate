using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_V._1
{
    public delegate void productHandler();
    public class GenericRepository<T> where T : Product
    {
        public event productHandler ProductAdd;
        public event productHandler ProductRemove;
        public event productHandler ProductUpdate;
        public event productHandler ProductSearch;

        public GenericRepository()
        {
            this.ProductAdd += new productHandler(OnItemAdd);
            this.ProductRemove += new productHandler(OnItemRemove);
            this.ProductUpdate += new productHandler(OnItemUpdate);
            this.ProductSearch += new productHandler(OnItemSearch);
        }

        public List<T> Products = new List<T>();

        public void Add(T product)
        {
            Products.Add(product);
            ProductAdd?.Invoke();
        }
        public void Remove(T product)
        {
            if (Products.Contains(product))
            {
                Products.Remove(product);
                ItemRemove(product);
            }
        }
        public void Update(T product)
        {
            var product_Index = Products.FindIndex(p => p.Product_Id == product.Product_Id);
            if(product_Index != -1)
            {
                Products[product_Index] = product;
                ProductUpdate?.Invoke();
            }
        }
        public List<T> getProducts()
        {
            return Products;
        }
        public void Search(T product)
        {
            var product_name = Products.Find(p => p.Product_Name.ToLower() == product.Product_Name.ToLower());
            if (product_name != null)
            {
                Console.WriteLine($"Name : {product_name.Product_Name} ");
                ProductSearch?.Invoke();
            }
        }
        public void TotalStockPrice(T product)
        {
            double total = 0;
            foreach (var item in Products)
            {
                Console.WriteLine($"Name : {item.Product_Name}");
                total = total + (item.Product_Stock * item.Product_Price);
                Console.WriteLine($"Total_Stock_Price : {total}");
            }
            
        }
        public void OnItemAdd()
        {
            Console.WriteLine("Product Added");
        }
        public void OnItemRemove()
        {
            Console.WriteLine("Product Remove");
        }
        public void ItemRemove(T Product)
        {
            ProductRemove?.Invoke();
        }
        public void OnItemUpdate()
        {
            Console.WriteLine("Product Updated");
        }
        public void OnItemSearch()
        {
            Console.WriteLine("Product Found");
        }
    }
}
