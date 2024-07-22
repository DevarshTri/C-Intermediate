using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalLibrary
{
    public class Car
    {
        public int Car_Id { get; set; }
        public string Car_Model { get; set; }
        public int Car_Year { get; set; }
        public bool IsCarAvailable { get; set; }

        public Car(int id , string car_model , int car_year) 
        { 
            Car_Id = id;
            Car_Model = car_model;
            Car_Year = car_year;
            IsCarAvailable = true;
        }
    }
}
