using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalLibrary
{
    public class GenericRepository<T,X,Y> where T : CarRental where X : Car where Y : Customer
    {
        public List<X> items = new List<X>();
        public List<T> rentals = new List<T>();
        public List<Y> cms = new List<Y>();

        public void Add(X item)
        {
            items.Add(item);
        }
        public void Add_cm(Y cm)
        {
            cms.Add(cm);
        }
        public void Remove(X item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
        }
        public void Car_Rent(T rental, int carid , int customerid)
        {
            var car = items.Find(x=> x.Car_Id == carid);
            var customer = cms.Find(c => c.Customer_Id == customerid);
            if(car != null && customer != null)
            {
                if (car.IsCarAvailable)
                {
                    car.IsCarAvailable = false;
                    
                    
                    rental.bookings[customer] = car;
                    Console.WriteLine($"{customer.Customer_Name} has rented {car.Car_Model}");
                }
                else
                {
                    Console.WriteLine("Car is available for rent");
                }
            }
            else
            {
                Console.WriteLine("Car or Customer Not Found");
            }
        }
        public void Car_Return(T rental,int carid, int customerid)
        {
            var car = items.Find(x => x.Car_Id == carid);
            var customer = cms.Find(c => c.Customer_Id == customerid);
            if (car != null && customer != null)
            {
                if (rental.bookings.ContainsKey(customer))
                {
                    rental.bookings[customer] = car;
                    car.IsCarAvailable = true;
                    rental.bookings.Remove(customer);
                    Console.WriteLine($"{customer.Customer_Name} has return {car.Car_Model}");
                }
                else
                {
                    Console.WriteLine("Car is not rented");
                }
            }
            else
            {
                Console.WriteLine("Car or Customer Not Found");
            }
        }
        public List<X> Display_Available_Cars()
        {
            return items;
        }
        public List<X> Display_All()
        {
            return items;
        }
    }
}
