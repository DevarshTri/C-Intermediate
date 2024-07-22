using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerToOrderL
{
    public class Customer
    {
        public int Customer_ID { get; set; }
        public string Customer_Name { get; set; }

        public GenericRepository<Order> OrderRepository { get; set; }

        public Customer(int cid , string cname) 
        {
            Customer_ID = cid;
            Customer_Name = cname;
            OrderRepository = new GenericRepository<Order>();
        }
    }
}
