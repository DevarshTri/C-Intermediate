using CarRentalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FinalCarRental finalCarRental = new FinalCarRental();

            int choice;
            do
            {
                Console.WriteLine("---------- Car Rental -----------");
                Console.WriteLine("1. Add Car");
                Console.WriteLine("2. Add Customer");
                Console.WriteLine("3. Rent Car");
                Console.WriteLine("4. Return Car");

                Console.WriteLine("Enter Your Choice:");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Car Id:");
                        int id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Car Model:");
                        string model = Console.ReadLine();

                        Console.WriteLine("Enter Car Year:");
                        int year = int.Parse(Console.ReadLine());

                        Car car = new Car(id, model, year);

                        finalCarRental.Add(car);
                        break;
                    case 2:
                        Console.WriteLine("Enter Customer Id:");
                        int customer_id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Customer Name:");
                        string customer_Name = Console.ReadLine();

                        Console.WriteLine("Enter Customer City:");
                        string city = Console.ReadLine();

                        Customer customer = new Customer(customer_id, customer_Name, city);

                        finalCarRental.Add_cm(customer);
                        break;
                    case 3:
                        Console.WriteLine("Enter Car Id:");
                        int c_id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Customer Id:");
                        int cm_id = int.Parse(Console.ReadLine());

                        finalCarRental.Rent_Car(c_id, cm_id);   
                        break;
                    case 4:
                        Console.WriteLine("Enter Car Id:");
                        int c1_id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Customer Id:");
                        int cm1_id = int.Parse(Console.ReadLine());

                        finalCarRental.Return_Car(c1_id, cm1_id);
                        break;
                }
            } while (choice != 3);
        }
    }
}
