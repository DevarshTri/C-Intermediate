using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalLibrary
{
    public class CarRental
    {
        public List<Car> acars = new List<Car>();
        public List<Customer> customers = new List<Customer>();
        public Dictionary<Customer , Car> bookings = new Dictionary<Customer , Car>();

        public CarRental(List<Car> acars , List<Customer> customers , Dictionary<Customer,Car> bookings)
        {
            this.acars = acars;
            this.customers = customers;
            this.bookings = bookings;
        }
    }
}
