using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement;
namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 c = new Class1();

            int choice;
            do
            {
                Console.WriteLine("------------- Library Management ---------------");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Update Book");
                Console.WriteLine("4. Display Available Books");              
                Console.WriteLine("5. Borrow Book");
                Console.WriteLine("6. Display All Books");
                Console.WriteLine("7. Return Book");
                Console.WriteLine("8. Search Book");
                Console.WriteLine("9. Exit");
                Console.Write("Please Enter your choice : ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("--------- Add Details ---------");
                        Console.Write("Enter Id:");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Title:");
                        string title = Console.ReadLine();

                        Console.Write("Enter Author:");
                        string author = Console.ReadLine();

                        Console.Write("Enter Price:");
                        double price = double.Parse(Console.ReadLine());

                        Book newbook = new Book(id, title, author, price);
                        c.Add(newbook);
                        break;

                    case 2:
                        Console.WriteLine("---------- Remove Books ---------");
                        Console.Write("Enter Id for Remove Book:");
                        int R_id = int.Parse(Console.ReadLine());
                        try
                        {
                            c.Remove(R_id);
                        }
                        catch (BookNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 3:
                        Console.WriteLine("----------- Update Details -------------");
                        try
                        {
                            Console.Write("Enter Id for book Update:");
                            int U_id = int.Parse(Console.ReadLine());

                            Console.Write("Enter Title:");
                            string U_title = Console.ReadLine();

                            Console.Write("Enter Author:");
                            string U_author = Console.ReadLine();

                            Console.Write("Enter Price:");
                            double U_price = double.Parse(Console.ReadLine());

                            c.Update(U_id, U_title, U_author, U_price);
                        }
                        catch (BookNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 4:
                        Console.WriteLine("Books In Library:");
                        c.DisplayAvailableBooks();
                        break;

                    case 5:
                        Console.Write("Enter Id for Borrow:");
                        int B_id = int.Parse(Console.ReadLine());
                        try
                        {
                            c.Borrow_Book(B_id);
                        }
                        catch(BookNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 6:
                        Console.WriteLine("Books In Library:");
                        c.DisplayAll();
                        break;

                    case 7:
                        Console.Write("Enter ID for return:");
                        int r_id = int.Parse(Console.ReadLine());

                        try
                        {
                            c.Return_Book(r_id);
                        }
                        catch (BookNotReturnException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 8:
                        Console.Write("Enter Title for searching book:");
                        string s_title = Console.ReadLine();

                        c.Search_Book(s_title);
                        break;

                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice Please Enter Correct Choice");
                        break;
                }
            } while (choice != 9);
        }
    }
}
