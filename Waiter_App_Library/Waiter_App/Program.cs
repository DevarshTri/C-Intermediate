using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter_App_Library;

namespace Waiter_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            WaiterManager manager = new WaiterManager();

            int choice;
            do
            {
                Console.WriteLine("---------- Waiter App ---------");
                Console.WriteLine("1. Add Orders");
                Console.WriteLine("2. Display Orders");
                Console.WriteLine("3. Update Order Status");
                Console.WriteLine("4. Exit");

                Console.Write("Enter Your Choice:");
                choice = int.Parse(Console.ReadLine());

               
            } while (choice != 4);
        }
    }
}
