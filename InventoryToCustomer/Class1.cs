using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryToCustomer
{
    public class Inventory
    {
       //public GenericRepository<Product> productRepository = new GenericRepository<Product>();

       public List<Supplier> Suppliers = new List<Supplier>();
       // public List<Product> Products = new List<Product>();    

        //Add Supplier
        public void Add_Supplier(Supplier supplier)
        {
            Suppliers.Add(supplier);
            Console.WriteLine("Supplier Added");
        }
        // Remove Supplier
        public void Remove_Supplier(int s_id)
        {
            var supplier_id = Suppliers.Find(s => s.Supplier_Id == s_id);
            if (supplier_id != null)
            {
                Suppliers.Remove(supplier_id);
                Console.WriteLine("Supplier Remove");
            }
            else
            {
                throw new SupplierNotFoundException("Supplier Not Found");
            }
        }
        // Update Supplier
        public void Update_Supplier(int s_id , string name)
        {
            var su_id = Suppliers.Find(s => s.Supplier_Id == s_id);
            if (su_id != null)
            {
                su_id.Supplier_Name = name;
                Console.WriteLine("Supplier Updated");
            }
        }
       // Add Product For Supplier
        public void Add(int sid ,Product product)
        {
            var id = Suppliers.Find(s => s.Supplier_Id==sid);
            if(id != null)
            {
                id.ProductRepository.Add(product);
            }
            else
            {
                throw new SupplierNotFoundException("Supplier Not Found");
            }
            
        }
        // Remove Product For Supplier
        public void Remove(int Supplier_id ,int Productid)
        {
            var r_id = Suppliers.Find(s => s.Supplier_Id.Equals(Supplier_id));
            var productid = r_id.ProductRepository.items.Find(p => p.Product_Id == Productid);
            if (productid != null && r_id != null)
            {
                r_id.ProductRepository.Remove(productid);
                
            }
            else
            {
                throw new ProductNotFoundException("Product Not Found");
                throw new SupplierNotFoundException("Supplier Not Found");
            }
        }
        // Update Product For Supplier
        public void Update(int sid ,int pid, string pname, double price, int pstock)
        {
            var supplier = Suppliers.Find(s => s.Supplier_Id==sid);
            var product = supplier.ProductRepository.items.Find(p => p.Product_Id == pid);
            if (product != null)
            {
                product.Product_Name = pname;
                product.Product_Price = price;
                product.Product_Stock = pstock;
                supplier.ProductRepository.Update(product);
            }
            else
            {
                throw new ProductNotFoundException("Product Not Found");
                throw new SupplierNotFoundException("Supplier Not Found");
            }
        }
        // Display All Suppliers
        public void Display_Suppliers()
        {
            for(int i=0; i< Suppliers.Count; i++)
            {
                var supplier = Suppliers[i];
                Console.WriteLine($"{i+1}.");
                Console.WriteLine($"ID:{supplier.Supplier_Id}");
                Console.WriteLine($"Name:{supplier.Supplier_Name}");
            }
        }
        // Display All Products
        public void DisplayAllProducts()
        {
            foreach (var item in Suppliers)
            {
                var products = item.ProductRepository.GetProducts();
                foreach (var item1 in products)
                {
                    Console.WriteLine($"ID:{item1.Product_Id}");
                    Console.WriteLine($"Name:{item1.Product_Name}");
                    Console.WriteLine($"Stock:{item1.Product_Stock}");
                }
            }
        }
        // Display Products By Supplier ID
        public void DisplayProducts(int sid)
        {
            var supplier = Suppliers.Find(s => s.Supplier_Id == sid);
            List<Product> products1 = supplier.ProductRepository.GetProducts();

            if(supplier == null || supplier.ProductRepository == null || products1 == null || products1.Count == 0)
            {
                Console.WriteLine("Details Not Found");
            }
            else
            {
                for (int i = 0; i < products1.Count; i++)
                {
                    var product = products1[i];
                    Console.WriteLine($"{i + 1}");
                    Console.WriteLine($"Name : {product.Product_Name}");
                    Console.WriteLine($"Price : {product.Product_Price}");
                }
            }
           
        }
        // Search Supplier
        public void Search_Supplier(string s_name)
        {
            var supplier = Suppliers.Find(s => s.Supplier_Name.ToLower() == s_name.ToLower());
            if (supplier != null)
            {
                Console.WriteLine("Supplier Found");
            }
            else
            {
                Console.WriteLine("Supplier Not found");
            }
        }
        // Search Product by Name
        public void Search_Product(string name)
        {
            if (Suppliers.Count > 0)
            {
                foreach (var item in Suppliers)
                {
                    item.ProductRepository.Search(name);
                }
            }
            else
            {
                Console.WriteLine("Product Not Found");
            }
        }
        //Update Stock
        public void Update_Stock(int supplierId, int productId, int stock)
        {
            // Ensure Suppliers list is not null
            if (Suppliers == null)
            {
                Console.WriteLine("Suppliers list is null.");
                return;
            }

            // Find the supplier by id
            var supplier_stock = Suppliers.Find(s => s.Supplier_Id == supplierId);

            // Check if supplier is found
            if (supplier_stock == null)
            {
                Console.WriteLine("Supplier not found.");
                return;
            }

            // Ensure ProductRepository and its items are not null
            if (supplier_stock.ProductRepository == null || supplier_stock.ProductRepository.items == null)
            {
                Console.WriteLine("Product repository is null.");
                return;
            }

            // Find the product by id
            var product = supplier_stock.ProductRepository.items.FirstOrDefault(p => p.Product_Id == productId);

            // Check if product is found
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            // Update the product stock
            product.Product_Stock = stock;
            supplier_stock.ProductRepository.Update(product);
            Console.WriteLine("Stock Updated");
        }
        
        // Highest stock
        public void H_Stock()
        {
            foreach (var item in Suppliers)
            {
                item.ProductRepository.Highest_Stock();
            }
        }

        // Product Show By stock
        public void Stock_product(int stock)
        {
            foreach (var item in Suppliers)
            {
                item.ProductRepository.Stock_item(stock);
            }
        }
    }
}
