using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Waiter_App_Library
{
    public class WaiterManager
    {
         public List<Table> tables = new List<Table>();

        public void AddOrder(int tableno , Order order)
        {
            var table = tables.Find(t => t.TableNumber == tableno);
            if (table != null)
            {
                table.orders.Add(order);
                table.IsOccupied = true;
            }
            else
            {
                Console.WriteLine("Table Not Found");
            }
        }
        public void UpdateOrderStatus(int tid , int oid , string status)
        {
            var table = tables.Find(t => t.TableNumber==tid);
            var order = table.orders.Find(o => o.Id == oid);
            if(table != null && order != null)
            {
                order.Status = status;
                Console.WriteLine($"Order Status Updated : {order.Status}");
            }
            else
            {
                Console.WriteLine("Table Not Found");
            }
        }
    }
}
