using InventoryProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            try
            {
                int choice;
                do
                {
                    Console.WriteLine("--------- Inventory Manage Dashboard ------------");
                    Console.WriteLine("1. Add Product");
                    Console.WriteLine("2. Remove Product");
                    Console.WriteLine("3. Update Product");
                    Console.WriteLine("4. List Of Products");
                    Console.WriteLine("5. Calculate Price Of Product");
                    Console.WriteLine("6. Search Product");
                    Console.WriteLine("7. Exit");
                    Console.Write("Please Enter Your Choice:");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            try
                            {
                                Console.Write("Enter Product Id:");
                                int p_id = int.Parse(Console.ReadLine());

                                Console.Write("Enter Product Name:");
                                string p_name = Console.ReadLine();

                                Console.Write("Enter Product Catrgory:");
                                string p_category = Console.ReadLine();

                                Console.Write("Enter Product Quantity:");
                                int p_quantity = int.Parse(Console.ReadLine());

                                Console.Write("Enter Product Price:");
                                double p_price = double.Parse(Console.ReadLine());

                                Product newProduct = new Product(p_id, p_name, p_category, p_quantity, p_price);
                                inventory.Add(newProduct);
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

                        case 2:
                            try
                            {
                                Console.Write("Enter Product Name:");
                                string r_name = Console.ReadLine();

                                inventory.Remove(r_name);
                            }
                            catch (ProductNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
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

                        case 3:
                            try
                            {
                                Console.Write("Enter Product Id:");
                                int U_id = int.Parse(Console.ReadLine());

                                Console.Write("Enter Product Name:");
                                string U_name = Console.ReadLine();

                                Console.Write("Enter Product Catrgory:");
                                string U_category = Console.ReadLine();

                                Console.Write("Enter Product Quantity:");
                                int U_quantity = int.Parse(Console.ReadLine());

                                Console.Write("Enter Product Price:");
                                double U_price = double.Parse(Console.ReadLine());

                                inventory.Update(U_id, U_name, U_category, U_quantity, U_price);
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
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

                        case 4:
                            Console.WriteLine("------------ List Of Products ----------------");
                            inventory.GetProducts();
                            break;

                        case 5:
                            try
                            {
                                Console.Write("Enter Product Id:");
                                int C_id = int.Parse(Console.ReadLine());

                                Console.Write("Enter Product Name:");
                                string C_name = Console.ReadLine();

                                //Console.Write("Enter Product Quantity:");
                                //int C_quantity = int.Parse(Console.ReadLine());

                                //Console.Write("Enter Product Price:");
                                //double C_price = double.Parse(Console.ReadLine());

                                inventory.Total_Price(C_id, C_name);
                            }
                            catch (ProductNotFoundException ex)
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

                        case 6:
                            try
                            {
                                Console.Write("Enter Product Name:");
                                string s_name = Console.ReadLine();

                                inventory.Search(s_name);
                            }
                            catch (ProductNotFoundException ex)
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

                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Choice Please Enter Correct Choice");
                            break;
                    }

                } while (choice != 7);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
