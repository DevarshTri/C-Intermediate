using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerToOrderL
{
    public delegate void OrderHandler();
    public class GenericRepository<T> where T : Order
    {
        public event OrderHandler OrderAdd;
        public event OrderHandler OrderRemove;
        public event OrderHandler OrderUpdate;

        public GenericRepository()
        {
            this.OrderAdd += new OrderHandler(OnOrderAdd);
            this.OrderRemove += new OrderHandler(OnOrderRemove);
            this.OrderUpdate += new OrderHandler(OnOrderUpdate);
        }

        public List<T> orders = new List<T> ();

        public void Add(T order)
        {
            orders.Add (order);
            OrderAdd?.Invoke();
        }
        public void Remove(T order)
        {
            if(orders.Contains(order))
            {
                orders.Remove(order);
                OrderRemove?.Invoke();
            }
        }
        public void Update(T order)
        {
            var O = orders.FindIndex(o => o.Id == order.Id);
            if(O != -1)
            {
                orders[O]=order;
                OrderUpdate?.Invoke();
            }
        }
        public void Search(T order)
        {
            var order_name = orders.Find(o=> o.Product.Name.ToLower() == order.Product.Name.ToLower());
            if(order_name != null)
            {
                Console.WriteLine("Order Found");
            }
            else
            {
                throw new OrderNotFoundException("Order Not Found");
            }
        }
        public void OnOrderAdd()
        {
            Console.WriteLine("Order Added");
        }
        public void OnOrderRemove()
        {
            Console.WriteLine("Order Remove");
        }
        public void OnOrderUpdate()
        {
            Console.WriteLine("Order Updated");
        }
    }
}
