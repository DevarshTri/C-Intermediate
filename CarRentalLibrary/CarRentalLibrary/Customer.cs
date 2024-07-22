using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalLibrary
{
    public class Customer
    {
        public int Customer_Id { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_City { get; set; }

        public Customer(int Customer_Id, string Customer_Name, string Customer_City)
        {
            this.Customer_Id = Customer_Id;
            this.Customer_Name = Customer_Name;
            this.Customer_City = Customer_City;
        }
    }
}
