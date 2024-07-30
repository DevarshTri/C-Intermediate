using InventoryToCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InventoryToCustomerApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var exist_id = 0;
            var found1_id = 0;
            var products = 0;
            Inventory inventory = new Inventory();

            int choice;
            do
            {
                Console.WriteLine("--------- Inventory DashBoard -------------");
                Console.WriteLine("1. Add Product For Supplier");
                Console.WriteLine("2. Remove Product For Supplier");
                Console.WriteLine("3. Update Product For Supplier");
                Console.WriteLine("4. Display All Products");
                Console.WriteLine("5. Search Product");
                Console.WriteLine("6. Add Supplier");
                Console.WriteLine("7. Remove Supplier");
                Console.WriteLine("8. Update Supplier");
                Console.WriteLine("9. Display All Supplier");
                Console.WriteLine("10. Display Product by Supplier");
                Console.WriteLine("11. Search Supplier");
                Console.WriteLine("12. Update Stock");
                Console.WriteLine("13. Highest Stock Products");
                Console.WriteLine("14. Stock By Product List");
                Console.WriteLine("15. Exit");

                Console.Write("Enter Your Choice:");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Your choice is Valid");
                }
                else
                {
                    Console.WriteLine("Please Enter Correct Choice");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("----------- ADD PRODUCT -------------");
                        try
                        {
                            Console.Write("Enter Supplier ID:");
                            int s2_id = int.Parse(Console.ReadLine());

                            var exist_sid = inventory.Suppliers.Find(sa => sa.Supplier_Id == s2_id);
                            if (exist_sid == null)
                            {
                                Console.WriteLine("Supplier Not Found");
                                break;
                            }
                            Console.Write("Enter Product ID:");
                            int p_id = int.Parse(Console.ReadLine());
                            foreach (var item in inventory.Suppliers)
                            {
                                exist_id = ( item.ProductRepository.items.Where(p => p.Product_Id == p_id)).Count();
                                if (exist_id != 0)
                                {
                                    Console.WriteLine("ID already exists , please enter new ID");
                                    
                                }
                                break;
                            }
                            if (exist_id != 0)
                            {
                                exist_id = 0;
                                break;
                            }

                            

                            Console.Write("Enter Product Name:");
                            string p_name = Console.ReadLine();

                            Console.Write("Enter Product Price:");
                            double p_price = double.Parse(Console.ReadLine());

                            Console.Write("Enter Product Stock:");
                            int p_stock = int.Parse(Console.ReadLine());

                            Product newProduct = new Product(p_id, p_name, p_price, p_stock);
                            inventory.Add(s2_id,newProduct);
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 2:
                        Console.WriteLine("------------ REMOVE PRODUCT -------------");
                        try
                        {
                            Console.Write("Enter Supplier ID:");
                            int sid = int.Parse(Console.ReadLine());

                            Console.Write("Enter Product ID:");
                            int r_id = int.Parse(Console.ReadLine());

                            inventory.Remove(sid,r_id);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(ProductNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 3:
                        try
                        {
                            Console.WriteLine("------------ UPDATE PRODUCT -------------");
                            Console.Write("Enter Supplier ID For Product Update:");
                            int s1_id = int.Parse(Console.ReadLine());
                        
                            var found_id = inventory.Suppliers.Find(p => p.Supplier_Id == s1_id);
                            if (found_id != null)
                            {
                                Console.WriteLine("ID Found , Continue To Update Details");
                            }
                            else
                            {
                                Console.WriteLine("ID not found");
                                break;
                            }
                            Console.Write("Enter Product ID For Product Update:");
                            int p_id = int.Parse(Console.ReadLine());

                            foreach (var item in inventory.Suppliers)
                            {
                                found1_id = item.ProductRepository.items.Where(p => p.Product_Id == s1_id).Count();
                                if (found1_id != 0)
                                {
                                    Console.WriteLine("ID Found , Continue To Update Details");
                                }
                                else
                                {
                                    Console.WriteLine("ID not found");
                                    break;
                                }
                            }
                            if(found1_id == 0)
                            {
                                break;
                            }
                            Console.Write("Enter New Product Name:");
                            string u_name = Console.ReadLine();

                            Console.Write("Enter New Product Price:");
                            double u_price = double.Parse(Console.ReadLine());

                            Console.Write("Enter New Product Stock:");
                            int u_stock = int.Parse(Console.ReadLine());

                            inventory.Update(s1_id,p_id, u_name, u_price, u_stock);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 4:
                        Console.WriteLine("--------- Product List ----------");
                        inventory.DisplayAllProducts();
                        break;

                    case 5:
                        Console.WriteLine("---------- SEARCH SUPPLIER -----------");
                        try
                        {
                            Console.Write("Enter Product Name:");
                            string p_name = Console.ReadLine();
      
     
                            inventory.Search_Product(p_name);
                        }
                        catch (ProductNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 6:
                        Console.WriteLine("----------- ADD SUPPLIER ------------");
                        try
                        {
                            int s_id;
                            bool idExist;
                            do {
                                Console.Write("Enter Supplier Id:");
                                 //s_id = int.Parse(Console.ReadLine());
                                 while(!int.TryParse(Console.ReadLine(), out s_id))
                                {
                                    Console.WriteLine("Enter A number not string");
                                }

                                var sup_id = inventory.Suppliers.FirstOrDefault(x => x.Supplier_Id == s_id);
                                idExist = sup_id != null;
                                if (idExist)
                                {
                                    Console.WriteLine("Id Already exists , please enter new Id");
                                    break;
                                }
                            }while(idExist);
                            Console.Write("Enter Supplier Name:");
                            string s1_name = Console.ReadLine();

                            Supplier s = new Supplier(s_id, s1_name);
                            inventory.Add_Supplier(s);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 7:
                        Console.WriteLine("-------------- REMOVE SUPPLIER --------------");
                        try
                        {
                            Console.WriteLine("Enter Supplier ID:");
                            int sr_id = int.Parse(Console.ReadLine());

                            inventory.Remove_Supplier(sr_id);
                        }
                        catch(SupplierNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 8:
                        Console.WriteLine("-------------------- UPDATE SUPPLIER --------------");
                        try
                        {
                            Console.Write("Enter Supplier Id:");
                            int s3_id = int.Parse(Console.ReadLine());

                            var sup1_id = inventory.Suppliers.FirstOrDefault(x => x.Supplier_Id == s3_id);
                            if (sup1_id != null)
                            {
                                Console.WriteLine("Id found , Continue to update");
                            }
                            else
                            {
                                Console.WriteLine("Id Not Found");
                            }

                            Console.Write("Enter Supplier Name:");
                            string s_name = Console.ReadLine();

                            inventory.Update_Supplier(s3_id, s_name);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 9:
                        Console.WriteLine("---------- SUPPLIER LIST -----------");
                        inventory.Display_Suppliers();
                        break;

                    case 10:
                        Console.WriteLine("---------- Products Filter By Supplier ------------");
                        try
                        {
                            Console.Write("Enter Supplier ID:");
                            int id = int.Parse(Console.ReadLine());

                            inventory.DisplayProducts(id);
                        }
                        catch(SupplierNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 11:
                        Console.WriteLine("--------- Supplier List ----------");
                        Console.Write("Enter Supplier Name:");
                        string sup_name = Console.ReadLine();
                        inventory.Search_Supplier(sup_name);
                        break;

                    case 12:
                        Console.WriteLine("---------- UPDATE STOCK -----------");
                        try
                        {
                            Console.Write("Enter Supplier ID:");
                            int supplier_id = int.Parse(Console.ReadLine());
                            var ssp_id = inventory.Suppliers.FirstOrDefault(x => x.Supplier_Id == supplier_id);
                            if (ssp_id != null)
                            {
                                Console.WriteLine("Id Found Continue to Update");
                            }
                            else
                            {
                                Console.WriteLine("Id Not Found");
                            }
                            Console.Write("Enter Product ID:");
                            int product_id = int.Parse(Console.ReadLine());

                            foreach (var item in inventory.Suppliers)
                            {
                                products = item.ProductRepository.items.Where(p => p.Product_Id == product_id).Count();
                                if (products != 0)
                                {
                                    Console.WriteLine("Id found , Continue to Update");
                                }
                                else
                                {
                                    Console.WriteLine("Id not Found");
                                }
                            }
                            if (products == 0)
                            {
                                break;
                            }

                            Console.Write("Enter New Stock:");
                            int stock = int.Parse(Console.ReadLine());

                            inventory.Update_Stock(supplier_id , product_id , stock);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (NullReferenceException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 13:
                        inventory.H_Stock();
                        break;

                    case 14:
                        try
                        {
                            Console.WriteLine("------- Product List By Stock ------");
                            Console.WriteLine("Enter Stock:");
                            int s_stock = int.Parse(Console.ReadLine());

                            inventory.Stock_product(s_stock);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 15:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 15);
        }
    }
}
