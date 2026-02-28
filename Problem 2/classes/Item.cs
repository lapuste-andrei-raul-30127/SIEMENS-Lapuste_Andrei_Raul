using System;
using System.Collections.Generic;
using System.Linq;
  using System.Threading.Tasks;

namespace ConsoleApp1.classes
{
    internal class Item
    {
        public string ItemName { get; }
        public decimal Price { get; }
        public int Quantity { get; set; }

        public Item(string name, decimal p, int selectedQuantity) {
            this.Quantity= selectedQuantity;
            this.Price = p;
            this.ItemName = name.Trim();
        }

        public decimal getTotalPerItem() { 
            return Price*Quantity;
        }


    }
}
