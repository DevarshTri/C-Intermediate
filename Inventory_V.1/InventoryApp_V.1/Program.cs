using Inventory_V._1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InventoryApp_V._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            int choice;
            do
            {
                Console.WriteLine("-------------- Inventory Management -----------");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Remove Product");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Search Product");
                Console.WriteLine("5. Display Product");
                Console.WriteLine("6. Total Stock Price");
                Console.WriteLine("7. Exit");

                Console.Write("Please Enter Your Choice:");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Enter a number not any other value");
                }

                switch(choice)
                {
                    case 1:
                        Console.WriteLine("------ ADD PRODUCT -------");

                        int pid;
                        bool isExist;
                        do
                        {
                            Console.Write("Enter Product ID: ");
                            while (!int.TryParse(Console.ReadLine(), out pid))
                            {
                                Console.WriteLine("Enter a number, not any other value.");
                            }

                            var p_id = inventory.ProductRepository.Products.Find(p => p.Product_Id == pid);
                            isExist = p_id != null;

                            if (isExist)
                            {
                                Console.WriteLine("ID already exists, enter a new ID.");
                            }
                        } while (isExist);

                        string pname;
                        double price;
                        int stock;

                        try
                        {
                            Console.Write("Enter Product Name: ");
                            pname = Console.ReadLine();

                            Console.Write("Enter Product Price: ");
                            while (!double.TryParse(Console.ReadLine(), out price))
                            {
                                Console.WriteLine("Enter a valid price (number).");
                            }

                            Console.Write("Enter Product Stock: ");
                            while (!int.TryParse(Console.ReadLine(), out stock))
                            {
                                Console.WriteLine("Enter a valid stock quantity (number).");
                            }

                            Product product = new Product(pid, pname, price , stock);
                            inventory.Add(product);
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("------------- REMOVE PRODUCT ------------");
                        try
                        {
                            Console.WriteLine("Enter Product ID :");
                            int rid;
                            while (!int.TryParse(Console.ReadLine(), out rid))
                            {
                                Console.WriteLine("Enter Only Number");
                            }

                            inventory.Remove(rid);
                        }
                        catch(ProductNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        Console.WriteLine("----------- UPDATE CUSTOMER ----------");
                        int uid;
                        bool idExist;
                        do
                        {
                            Console.WriteLine("Enter Product ID :");
                            while (!int.TryParse(Console.ReadLine(), out uid))
                            {
                                Console.WriteLine("Enter Number Only");
                            }
                            var u_id = inventory.ProductRepository.Products.Find(p => p.Product_Id == uid);
                            idExist = u_id == null;
                            if (idExist)
                            {
                                Console.WriteLine("Id not Found, enter valid id");
                            }
                        } while (idExist);
                        string uname;
                        double uprice;
                        int ustock;

                        try
                        {
                            Console.Write("Enter Product Name: ");
                            uname = Console.ReadLine();

                            Console.Write("Enter Product Price: ");
                            while (!double.TryParse(Console.ReadLine(), out uprice))
                            {
                                Console.WriteLine("Enter a valid price (number).");
                            }

                            Console.Write("Enter Product Stock: ");
                            while (!int.TryParse(Console.ReadLine(), out ustock))
                            {
                                Console.WriteLine("Enter a valid stock quantity (number).");
                            }
                            inventory.Update(uid, uname ,uprice, ustock);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                        break;
                    case 4:
                        Console.WriteLine("--------- SEARCH CUSTOMER -----------");
                        try
                        {
                            Console.Write("Enter Product Name :");
                            string sname = Console.ReadLine();

                            inventory.Search(sname);
                        }
                        catch (ProductNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 5:
                        Console.WriteLine("-------- List Of Products ----------");
                        inventory.Display_Products();
                        break;
                    case 6:
                        Console.WriteLine("----------- Total Stock Price ----------");
                        try
                        {
                            Console.Write("Enter Product ID :");
                            int s_id;
                            while (!int.TryParse(Console.ReadLine(), out s_id))
                            {
                                Console.WriteLine("Enter Only Number");
                            }

                           inventory.Total_Stock_Price(s_id);
                         
                        }
                        catch(ProductNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                }

            } while (choice != 7);
        }
    }
}
