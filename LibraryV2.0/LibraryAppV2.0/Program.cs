using LibraryV2._0;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppV2._0
{
    public class Program
    {
        static void Main(string[] args)
        {
            LIbrary lIbrary = new LIbrary();

            int choice;
            do
            {
                Console.WriteLine("---------- Library Management ------------");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Update Book");
                Console.WriteLine("4. Display Books");
                Console.WriteLine("5. Search Book");
                Console.WriteLine("6. Exit");

                Console.Write("Enter Your Choice:");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Enter Number Not a String");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("----------- ADD BOOk -----------");
                        try
                        {
                            int id;
                            bool idExists;
                            do
                            {
                                Console.Write("Enter Book Id:");
                                while(!int.TryParse(Console.ReadLine(), out id))
                                {
                                    Console.WriteLine("Enter a number not a string");
                                }

                                var bookid = lIbrary.bookRepository.books.Find(b => b.Book_Id == id);
                                idExists = bookid != null;
                                if (idExists)
                                {
                                    Console.WriteLine("Id Already Exists , Please enter new Id");                                   
                                }
                            } while (idExists);

                            Console.Write("Enter Book Title:");
                            string title = Console.ReadLine();

                            Console.Write("Enter Book Author:");
                            string author = Console.ReadLine();

                            Console.Write("Enter Book Price:");
                            double price = double.Parse(Console.ReadLine());

                            Book newBook = new Book(id, title, author, price);
                            lIbrary.Add(newBook);
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
                            Console.WriteLine("-------- REMOVE BOOK ---------");
                            Console.Write("Enter Book Id:");
                            int r_id;
                            while(!int.TryParse(Console.ReadLine(), out r_id))
                            {
                                Console.WriteLine("Enter a number not a string");
                            }

                            lIbrary.Remove(r_id);
                        }
                        catch (BookNotFoundException ex)
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
                        Console.WriteLine("----------- UPDATE BOOK -------------");
                        try
                        {
                            int uid;
                            bool Idexists;
                            do
                            {
                                Console.Write("Enter Book Id for Update:");
                                while(!int.TryParse(Console.ReadLine(), out uid))
                                {
                                    Console.WriteLine("Enter a number not a string");
                                }

                                var u = lIbrary.bookRepository.books.Find(b => b.Book_Id == uid);
                                Idexists = u == null;
                                if (Idexists)
                                {
                                    Console.WriteLine("Id Not Found , Re-Enter ID");
                                }
                                else
                                {
                                    Console.WriteLine("Id Found");
                                }
                                
                            } while (Idexists);


                            Console.Write("Enter Book Title:");
                            string ut = Console.ReadLine();

                            Console.Write("Enter Book Author:");
                            string ua = Console.ReadLine();

                            Console.Write("Enter Book Price:");
                            double up = double.Parse(Console.ReadLine());

                            lIbrary.Update(uid, ut, ua, up);
                        }
                        catch (BookNotFoundException ex)
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
                    case 4:
                        Console.WriteLine("------------ Library -----------");
                        lIbrary.DisplayBooks();
                        break;
                    case 5:
                        Console.WriteLine("-------------- SEARCH BOOK -------------");
                        try
                        {
                            Console.Write("Enter Book Title:");
                            string st = Console.ReadLine();

                            lIbrary.Search(st);
                        }
                        catch (BookNotFoundException ex)
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
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 6);
        }
    }
}
