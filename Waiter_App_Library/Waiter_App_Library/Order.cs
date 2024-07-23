using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter_App_Library
{
    public class Order
    {
        public int Id { get; set; }
        public List<Menu> MenuItems { get; set; }
        public string Status { get; set; }

        public Order(int id)
        {
            Id = id;
            MenuItems = new List<Menu>();
            Status = "Preparing";
        }

    }
}
