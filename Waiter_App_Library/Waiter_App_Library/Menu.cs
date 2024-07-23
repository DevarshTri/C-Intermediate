using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter_App_Library
{
    public class Menu
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Menu(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
