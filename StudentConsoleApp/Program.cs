using StudentProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentDatabase studentDatabase = new StudentDatabase();
            //GenericRepository<Student> studentRepository = new GenericRepository<Student>();

            int choice;
            do
            {
                Console.WriteLine("------- Student Manage Dashboard -------");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Remove Student");
                Console.WriteLine("3. Display Students");
                Console.WriteLine("4. Update Student Details");
                Console.WriteLine("5. Search Student");
                Console.WriteLine("6. Exit");
                Console.Write("Enter Your Choice:");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.Write("Enter Student ID:");
                            int s_id = int.Parse(Console.ReadLine());

                            Console.Write("Enter Student Name:");
                            string s_name = Console.ReadLine();

                            Console.Write("Enter Student Email:");
                            string s_email = Console.ReadLine();

                            Console.Write("Enter Student Phone:");
                            long s_num = long.Parse(Console.ReadLine());

                            Console.Write("Enter Student City:");
                            string s_city = Console.ReadLine();

                            Student newStudent = new Student(s_id, s_name, s_email, s_num, s_city);
                            studentDatabase.Add(newStudent);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 2:
                        Console.Write("Enter Student Name:");
                        string r_name = Console.ReadLine();
                        try
                        {
                            studentDatabase.Remove(r_name);
                        }
                        catch (StudentNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 3:
                        Console.WriteLine("-------------- Student Details -------------------");
                        studentDatabase.GetAllStudents();
                        break;

                    case 4:
                        Console.WriteLine("-------------- Enter Id for Update details -----------------");
                        try
                        {
                            Console.Write("Enter Student ID:");
                            int U_id = int.Parse(Console.ReadLine());
                            //Student s_id = studentRepository.values.Find(st => st.Student_Id == U_id);
                            //if (s_id == U_id)
                            //{
                            //    throw new StudentNotFoundException("Student Not Found");
                            //}
                            Console.Write("Enter Student Name:");
                            string U_name = Console.ReadLine();

                            Console.Write("Enter Student Email:");
                            string U_email = Console.ReadLine();

                            Console.Write("Enter Student Phone:");
                            long U_phone = long.Parse(Console.ReadLine());

                            Console.Write("Enter Student City:");
                            string U_city = Console.ReadLine();

                            studentDatabase.Update(U_id, U_name, U_email, U_phone, U_city);
                           
                        }
                        catch (StudentNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                     
                    case 5:
                        try
                        {
                            Console.Write("Enter Student Name:");
                            string name = Console.ReadLine();

                            studentDatabase.Search(name);
                        }
                        catch(StudentNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default : Console.WriteLine("Invalid Choice please enter correct choice");
                        break;
                }
            } while (choice != 6);
        }
    }
}
