using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerToOrderL
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Order_date { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public double TotalPrice()
        {
            return Product.Price * Quantity;
        }

        public Order(int id , DateTime od , Product product , int quant)
        {
            Id = id;
            Order_date = od;
            Product = product;
            Quantity = quant;
        }
    }
}
