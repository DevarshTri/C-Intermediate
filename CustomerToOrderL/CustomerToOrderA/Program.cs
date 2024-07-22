using CustomerToOrderL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerToOrderA
{
    public class Program
    {
        static void Main(string[] args)
        {
            var found_id = 0;
            var exist_id = 0;
            CustomerManager customerManager = new CustomerManager();

            int choice;
            do
            {
                Console.WriteLine("------- Order Management ---------");
                Console.WriteLine("1. Add Order");
                Console.WriteLine("2. Remove Order");
                Console.WriteLine("3. Update Order");
                Console.WriteLine("4. Add Customer");
                Console.WriteLine("5. Remove Customer");
                Console.WriteLine("6. Update Customer");
                Console.WriteLine("7. Display Customers");
                Console.WriteLine("8. Search Customer");
                Console.WriteLine("9. Total Spending by customer");
                Console.WriteLine("10. Display Order By Customer");
                Console.WriteLine("11. Exit");

                Console.Write("Enter Your Choice :");
                while(!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Enter A numer Not any other value");
                }

                switch(choice)
                {
                    case 1:
                        try
                        {
                            Console.Write("Enter Customer Id :");
                            int c_id;                            
                            while (!int.TryParse(Console.ReadLine(), out c_id))
                            {
                                Console.WriteLine("Enter a number not any other value");
                            }

                            var customer2 = customerManager.customers.Find(c => c.Customer_ID == c_id);
                            if (customer2 != null)
                            {
                                Console.WriteLine("Id Found , Continue");
                            }
                            else
                            {
                                Console.WriteLine("Id not Found , re-enter");
                                break;
                            }

                            Console.Write("Enter Order Id :");
                            int id;
                            while(!int.TryParse(Console.ReadLine(),out id))
                            {
                                Console.WriteLine("Enter a number not any other value");
                            }

                            foreach (var item in customerManager.customers)
                            {
                                exist_id = item.OrderRepository.orders.Where(o => o.Id == id).Count();
                                if(exist_id != 0)
                                {
                                    Console.WriteLine("Id Already Exist , please enter new id");
                                }
                                break;
                            }
                            if(exist_id != 0)
                            {
                                exist_id = 0;
                                break;
                            }

                            Console.Write("Enter Order Date (yyyy-mm-dd) :");
                            DateTime date = DateTime.Parse(Console.ReadLine());

                            Console.Write("Enter Product Name :");
                            string name = Console.ReadLine();

                            Console.Write("Enter Product Price :");
                            double price = double.Parse(Console.ReadLine());

                            Console.Write("Enter Order Quantity :");
                            int quantity = int.Parse(Console.ReadLine());

                            Product product = new Product(name, price);
                            Order order = new Order(id, date, product, quantity);

                            customerManager.Add_Order(c_id, order);
                        }
                        catch (CustomerNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
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
                    case 2:
                        try
                        {
                            Console.Write("Enter Customer Id :");
                            int c1_id;
                            while (!int.TryParse(Console.ReadLine(), out c1_id))
                            {
                                Console.WriteLine("Enter a number not any other value.");
                            }

                            Console.Write("Enter Order Id :");
                            int r_id;
                            while (!int.TryParse(Console.ReadLine(), out r_id))
                            {
                                Console.WriteLine("Enter a number not any other value.");
                            }

                            customerManager.Remove_Order(c1_id, r_id);
                        }
                        catch (CustomerNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(OrderNotFoundException ex)
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
                    case 3:
                        try
                        {
                            Console.Write("Enter Customer Id for Update :");
                            int uc_id;
                            while(!int.TryParse(Console.ReadLine(), out uc_id))
                            {
                                Console.WriteLine("Enter a number not any other value");
                            }

                            var customer2 = customerManager.customers.Find(c => c.Customer_ID == uc_id);
                            if(customer2 != null)
                            {
                                Console.WriteLine("Id Found , Continue");
                            }
                            else
                            {
                                Console.WriteLine("Id not Found , re-enter");
                                break;
                            }
                            Console.Write("Enter Order Id for Update :");
                            int uo_id;                            
                            while (!int.TryParse(Console.ReadLine(), out uo_id))
                            {
                                Console.WriteLine("Enter a number not any other value");
                            }

                            foreach (var item in customerManager.customers) 
                            {
                                found_id = item.OrderRepository.orders.Where(o => o.Id == uo_id).Count();
                                if(found_id != 0)
                                {
                                    Console.WriteLine("Id found , Continue");
                                }
                                else
                                {
                                    Console.WriteLine("Id not Found");
                                }
                            }
                            if(found_id == 0)
                            {
                                break;
                            }

                            Console.Write("Enter Order Date :");
                            DateTime date1 = DateTime.Parse(Console.ReadLine());

                            Console.Write("Enter Product Name :");
                            string name1 = Console.ReadLine();

                            Console.Write("Enter Product Price :");
                            double price1 = double.Parse(Console.ReadLine());

                            Console.Write("Enter Order Quantity :");
                            int quantity1 = int.Parse(Console.ReadLine());

                            Product product1 = new Product(name1, price1);

                            customerManager.Update_Order(uc_id, uo_id, date1, product1, quantity1);
                            break;
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
                    case 4:
                        try
                        {
                            Console.Write("Enter Customer Id :");
                            int c2_id;

                            while (!int.TryParse(Console.ReadLine(), out c2_id))
                            {
                                Console.WriteLine("Enter a number not any other value.");
                            }

                            var customer3 = customerManager.customers.FirstOrDefault(x => x.Customer_ID == c2_id);
                            if (customer3 != null)
                            {
                                Console.WriteLine("Id Already Exist , Enter a new id");
                                break;
                            }

                            Console.Write("Enter Customer Name :");
                            string c_name = Console.ReadLine();

                            Customer customer = new Customer(c2_id, c_name);
                            customerManager.Add_Customer(customer);
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
                    case 5:
                        try
                        {
                            Console.Write("Enter Customer Id :");
                            int r1_id;
                            while (!int.TryParse(Console.ReadLine(), out r1_id))
                            {
                                Console.WriteLine("Enter a number not any other value.");
                            }

                            customerManager.Remove_Customer(r1_id);
                        }
                        catch(CustomerNotFoundException ex)
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
                        try
                        {
                            Console.Write("Enter Customer Id :");
                            int c3_id;
                            while (!int.TryParse(Console.ReadLine(), out c3_id))
                            {
                                Console.WriteLine("Enter a number not any other value.");
                            }

                            var c = customerManager.customers.Find(c2 => c2.Customer_ID == c3_id);
                            if (c != null)
                            {
                                Console.WriteLine("Id Found , continue");
                            }
                            else
                            {
                                Console.WriteLine("Id not found");
                                break;
                            }
                            Console.Write("Enter Customer Name :");
                            string c1_name = Console.ReadLine();

                            customerManager.Update_Customer(c3_id, c1_name);
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
                        customerManager.DisplayAllCustomer();
                        break;
                    case 8:
                        try
                        {
                            Console.Write("Enter Customer Name :");
                            string s_name = Console.ReadLine();

                            customerManager.Search_Customer(s_name);
                        }
                        catch(CustomerNotFoundException ex)
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
                    case 9:
                        try
                        {
                            Console.Write("Enter Customer Id :");
                            int t_id;

                            while (!int.TryParse(Console.ReadLine(), out t_id))
                            {
                                Console.WriteLine("Enter a number only");
                            }

                            customerManager.TotalSpending(t_id);
                            break;
                        }
                        catch (CustomerNotFoundException ex)
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
                    case 10:
                        try
                        {
                            Console.Write("Enter Customer Id :");
                            int d_id;

                            while(!int.TryParse(Console.ReadLine(), out d_id))
                            {
                                Console.WriteLine("Enter a number only");
                            }

                            customerManager.Display_Order_By_Customer(d_id);
                        }
                        catch (CustomerNotFoundException ex)
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
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;

                }
            } while (choice != 12);
        }
    }
}
