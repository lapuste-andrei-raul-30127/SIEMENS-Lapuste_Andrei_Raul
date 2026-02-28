using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.classes
{
    internal class Order
    {
        public int OrderID;
        public string CustomerName { get; }
        public DateTime DateTime { get; }
        public Dictionary<string, Item> OrderItems;

        public Order(string userName) {

            if (!string.IsNullOrEmpty(userName))
            {
                this.CustomerName = userName;
                this.DateTime = DateTime.Now;
                this.OrderItems = new Dictionary<string, Item>();
            }
            else throw new ArgumentNullException("userName");
        }

        public void addItemToOrder(Item itm)
        {
            
            if (itm is null)
                throw new ArgumentNullException("Item can't be null");
            else if (OrderItems.ContainsKey(itm.ItemName.ToLowerInvariant().Trim()))
            {
                OrderItems[itm.ItemName.ToLowerInvariant()].Quantity += itm.Quantity;
            }
            else { 
                OrderItems.Add(itm.ItemName.ToLowerInvariant(), itm);
            }
        }


        // 2.2 FUNCTIE FINAL PRICE
        public decimal CalculatePrice()
        {
            decimal price = OrderItems.Values.Sum(x => x.getTotalPerItem());
            return price>500 ? 0.9m* price: price;
        }

       
    }
}
