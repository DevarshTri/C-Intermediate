using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalLibrary
{
    public class FinalCarRental
    {
        GenericRepository<CarRental,Car , Customer> carRepository = new GenericRepository<CarRental, Car, Customer>();

        public void Add(Car car)
        {
            carRepository.Add(car);
            Console.WriteLine($"Car Added:{car.Car_Model}");
        }
        public void Add_cm(Customer customer)
        {
            carRepository.Add_cm(customer);
            Console.WriteLine("Customer Added");
        }
        public void Rent_Car(int cid , int cmid)
        {
            var car = carRepository.items.Find(c => c.Car_Id == cid);
            var customer = carRepository.cms.Find(cm => cm.Customer_Id == cmid);
            var rental = carRepository.rentals.FirstOrDefault();
            if(car != null && customer != null)
            {
                carRepository.Car_Rent(rental,cid , cmid);
            }
            else
            {
                Console.WriteLine("Car or Customer Not Found");
            }
        }
        public void Return_Car(int cid, int cmid)
        {
            var car = carRepository.items.Find(c => c.Car_Id == cid);
            var customer = carRepository.cms.Find(cm => cm.Customer_Id == cmid);
            var returns = carRepository.rentals.FirstOrDefault();
            if (car != null && customer != null)
            {
                carRepository.Car_Return(returns,cid, cmid);
            }
            else
            {
                Console.WriteLine("Car or Customer Not Found");
            }
        }
    }
}

