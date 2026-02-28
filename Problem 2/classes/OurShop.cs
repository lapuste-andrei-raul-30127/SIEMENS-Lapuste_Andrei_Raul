using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.classes
{
    internal class OurShop
    {
        public List<Order> ourOrders { get; }

        public OurShop() { 
            this.ourOrders = new List<Order>(); 
        }

        public void addOrder(Order order) {
            if (order is null)
                throw new ArgumentNullException("Order can't be null");
            order.OrderID= ourOrders.Count+1;
            ourOrders.Add(order);
        }

        //// 2.3 OUR BEST CUSTOMER 
        public string OurBestCustomer()
        {
            var result = ourOrders.GroupBy(p => p.CustomerName).Select(p => new
            {
                CustomerName = p.Key,
                Total = p.Sum( n=> n.CalculatePrice() )
            }).OrderByDescending(x=> x.Total).First();

            return result.CustomerName;
         
        }
        //// 2.4 
        public IOrderedEnumerable<(string ItemName, int ItemSales )> OurBestItemSold()
        {
 

            var result = ourOrders.SelectMany(s => s.OrderItems.Values)
                .GroupBy(g => g.ItemName)
                .Select(s1 => ( 
                    ItemName: s1.Key,
                    ItemSales: s1.Sum(sm => sm.Quantity)
                ))
            .OrderByDescending(x=> x.ItemSales);


            return result;
        }
    }
}
