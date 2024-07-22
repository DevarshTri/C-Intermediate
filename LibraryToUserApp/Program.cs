using LibraryToUser;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryToUserApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            
                int choice;
                do
                {
                    Console.WriteLine("---------------- Library Management User -----------------");
                    Console.WriteLine("1. Add User");
                    Console.WriteLine("2. Remove User");
                    Console.WriteLine("3. Update User");
                    Console.WriteLine("4. Add Book For User");
                    Console.WriteLine("5. Remove Book For User");
                    Console.WriteLine("6. Update Book For User");
                    Console.WriteLine("7. Display Book For User");
                    Console.WriteLine("8. Display Users");
                    Console.WriteLine("9. Display All Books");
                    Console.WriteLine("10. Exit");
                
                    Console.WriteLine("Please Enter Your Choice:");
              
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    //Console.WriteLine($"You Enter Valid Choice :{choice}");
                }
                else
                {
                    Console.WriteLine("Enter Correct Format");
                }
                    switch (choice)
                    {
                        case 1:
                        Console.WriteLine("-------------- ADD USER ----------------");
                        Console.Write("Enter User Id:");
                            int uid = int.Parse(Console.ReadLine());

                            var user_id = library.users.Find(u => u.Id == uid);
                            if (user_id != null)
                            {
                                Console.WriteLine("Please Enter New Id , Id Already Existed");
                                break;
                            }

                            Console.Write("Enter User Name:");
                            string uname = Console.ReadLine();


                            User user = new User(uid, uname);

                            library.Add(user);
                            break;
                        case 2:
                        Console.WriteLine("--------------- REMOVE USER ---------------");
                        try
                            {
                                Console.Write("Enter User Id:");
                                int rid = int.Parse(Console.ReadLine());

                                library.Remove(rid);
                                Console.WriteLine("Removed");
                            }
                            catch (UserNotFoundException ex)
                            {
                                Console.WriteLine("Please Enter Correct Id" + ex.Message);
                            }

                            break;
                        case 3:
                        Console.WriteLine("------------------- UPDATE USER -----------------");
                        try
                            {
                                Console.Write("Enter User Id:");
                                int u_id = int.Parse(Console.ReadLine());

                                var uy_id = library.users.Find(u => u.Id == u_id);
                                if (uy_id != null)
                                {
                                    Console.WriteLine("Id Found , Continue to Update Details");
                                }
                                else
                                {
                                    Console.WriteLine("Id not match or not found");
                                    break;
                                }

                                Console.Write("Enter new User Name:");
                                string u_name = Console.ReadLine();

                                library.Update(u_id, u_name);
                                Console.WriteLine("updated");
                            }
                            catch (UserNotFoundException ex)
                            {
                                Console.WriteLine("Please Enter Correct Id" + ex.Message);
                            }

                            break;
                        case 4:
                        Console.WriteLine("------------- ADD BOOK ----------------");
                        Console.Write("Enter User ID to Assign Book For User: ");
                            int usr_id = int.Parse(Console.ReadLine());

                            Console.Write("Enter Book Id:");
                            int bid = int.Parse(Console.ReadLine());

                            var b_id = library.books.FirstOrDefault(b => b.Book_Id == bid);
                            if (b_id != null)
                            {
                                Console.WriteLine("Please Enter New Id , Id Already Existed");
                                break;
                            }

                            Console.Write("Enter Book Title:");
                            string btitle = Console.ReadLine();

                            Console.Write("Enter Book Author:"); ;
                            string bauthor = Console.ReadLine();

                            Console.Write("Enter Book Price:");
                            double price = double.Parse(Console.ReadLine());

                            Book newBook = new Book(bid, btitle, bauthor, price);
                            library.AddBook(usr_id, newBook);
                            break;

                        case 5:
                        Console.WriteLine("---------------- REMOVE BOOK ---------------");
                        try
                            {
                                Console.Write("Enter User ID to Remove Book For User: ");
                                int R_id = int.Parse(Console.ReadLine());

                                Console.Write("Enter Book Id:");
                                int R1_id = int.Parse(Console.ReadLine());

                                library.RemoveBook(R_id, R1_id);
                            }
                            catch (BookNotFoundException ex)
                            {
                                Console.WriteLine("Please Enter Correct Id" + ex.Message);
                            }

                            break;

                        case 6:
                        Console.WriteLine("---------------- UPDATE BOOK ------------------");
                        try
                            {
                                Console.Write("Enter User ID to Update Book For User: ");
                                int U_id = int.Parse(Console.ReadLine());

                                var update_id = library.users.FirstOrDefault(b => b.Id == U_id);
                                if (update_id != null)
                                {
                                    Console.WriteLine("Id Found Or continue Update");
                                }
                                else
                                {
                                    Console.WriteLine("Id not Found Or not match");
                                    break;
                                }

                                Console.Write("Enter Book Id:");
                                int U1_id = int.Parse(Console.ReadLine());

                                var Ub_id = library.books.FirstOrDefault(b => b.Book_Id == U1_id);
                                if (Ub_id != null)
                                {
                                    Console.WriteLine("Id Found Or continue Update");
                                }
                                else
                                {
                                    Console.WriteLine("Id not Found Or not match");
                                    break;
                                }

                                Console.Write("Enter Book Title:");
                                string U_title = Console.ReadLine();

                                Console.Write("Enter Book Author:"); ;
                                string U_author = Console.ReadLine();

                                Console.Write("Enter Book Price");
                                double U_price = double.Parse(Console.ReadLine());

                                library.UpdateBook(U1_id, U1_id, U_title, U_author, U_price);
                            }
                            catch (BookNotFoundException ex)
                            {
                                Console.WriteLine("Please Enter Correct Id" + ex.Message);
                            }

                            break;

                        case 7:
                            Console.WriteLine("----------- Display Books By Specific User -----------------");

                            Console.Write("Enter User ID to Get Book For User: ");
                            int G_id = int.Parse(Console.ReadLine());
                            library.DisplayBooks(G_id);

                            break;

                        case 8:
                            Console.WriteLine("----------- All Users ----------------");
                            library.DisplayAllUsers();
                            break;

                        case 9:
                            Console.WriteLine("--------------- Books In Library -------------");
                            library.DisplayAllBooks();
                            break;

                        case 10:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }

                } while (choice != 10);
            }
            
            }
        }
   

