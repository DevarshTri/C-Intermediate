using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter_App_Library
{
    public class Table
    {
        public int TableNumber { get; set; }
        public List<Order> orders { get; set; }
        public bool IsOccupied { get; set; }

        public Table(int tableNumber)
        {
            this.TableNumber = tableNumber;
            orders = new List<Order>();
            IsOccupied = false;
        }
    }
}
