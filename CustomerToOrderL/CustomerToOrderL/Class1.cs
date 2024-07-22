using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerToOrderL
{
    public class CustomerManager
    {
        public List<Customer> customers = new List<Customer>();

        public void Add_Customer(Customer customer)
        {
            customers.Add(customer);
            Console.WriteLine("Customer Added");
        }
        public void Remove_Customer(int c_id)
        {
            var customer = customers.Find(c => c.Customer_ID == c_id);  
            if(customer != null)
            {
                customers.Remove(customer);
                Console.WriteLine("Customer Removed");
            }
            else
            {
                throw new CustomerNotFoundException("Customer Not Found");
            }
        }
        public void Update_Customer(int c_id, string c_name)
        {
            var customer = customers.Find(c => c.Customer_ID == c_id);
            if(customer != null)
            {
                customer.Customer_Name = c_name;
                Console.WriteLine("Customer Updated");
            }
            else
            {
                throw new CustomerNotFoundException("Customer Not Found");
            }
        }
        public void DisplayAllCustomer()
        {
            Console.WriteLine("-------- Customer List ----------");
            for(int i = 0; i < customers.Count; i++)
            {
                var customer = customers[i];
                Console.WriteLine($"No : {i+1}");
                Console.WriteLine($"ID : {customer.Customer_ID}");
                Console.WriteLine($"Name : {customer.Customer_Name}");
            }
        }
        public void Search_Customer(string name)
        {
            var customer = customers.Find(c => c.Customer_Name.ToLower() ==  name.ToLower());
            if(customer != null)
            {
                Console.WriteLine("Customer Found");
            }
            else
            {
                throw new CustomerNotFoundException("Customer Not Found");
            }
        }
        public void TotalSpending(int id)
        {
            var customer = customers.FirstOrDefault( c => c.Customer_ID == id);
            if(customer != null)
            {
                
                //foreach (var item in customers)
                //{
                //    var order = customer.OrderRepository.orders;
                //    foreach (var item1 in order)
                //    {
                //        double total = item1.Quantity * item1.Product.Price;
                //    }
                //}
                double totalspending = customer.OrderRepository.orders.Sum(o => o.TotalPrice());
                Console.WriteLine($"Total Expense : {totalspending}");
            }
            else
            {
                throw new CustomerNotFoundException("Customer Not Found");
            }
        }
        public void Add_Order(int cid , Order order)
        {
            var customer = customers.Find(c => c.Customer_ID == cid);
            if(customer != null)
            {
                customer.OrderRepository.Add(order);
            }
            else
            {
                throw new CustomerNotFoundException("Customer Not Found");
            }
        }
        public void Remove_Order(int cid , int oid)
        {
            var customer = customers.Find(c => c.Customer_ID == cid);
            var order = customer.OrderRepository.orders.Find(o => o.Id == oid);
            if(order != null && customer != null)
            {
                customer.OrderRepository.Remove(order);
            }
            else
            {
                throw new CustomerNotFoundException("Customer Not Found");
                throw new OrderNotFoundException("Order Not Found");
            }
        }
        public void Update_Order(int cid , int oid , DateTime odate , Product product , int oquantity)
        {
            var customer = customers.Find(c => c.Customer_ID==cid);
            var order = customer.OrderRepository.orders.Find(o => o.Id == oid);
            if( order != null && customer != null )
            {
                order.Order_date = odate;
                order.Product = product;
                order.Quantity = oquantity;
                customer.OrderRepository.Update(order);
            }
            else
            {
                throw new CustomerNotFoundException("Customer Not Found");
                throw new OrderNotFoundException("Order Not Found");
            }
        }
        public void Display_Order_By_Customer(int cid)
        {
            var customer = customers.Find(c => c.Customer_ID==cid);
            if( customer != null )
            {
                var order = customer.OrderRepository.orders;
                if( order != null )
                {
                    foreach (var item in order)
                    {
                        Console.WriteLine($"Name : {item.Product.Name}");
                        Console.WriteLine($"Price : {item.Product.Price}");
                        Console.WriteLine($"Quantity : {item.Quantity}");
                        Console.WriteLine($"Date : {item.Order_date}");
                    }
                }
                else
                {
                    throw new OrderNotFoundException("Order Not Found");
                }
            }
            else
            {
                throw new CustomerNotFoundException("Customer Not Found");
            }
        }
    }
}
