using ConsoleApp1.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Order order1 = new Order("Mihai");
                order1.addItemToOrder(new Item("Mouse", 23m, 1));
                order1.addItemToOrder(new Item("Laptop", 400m, 1));
                order1.addItemToOrder(new Item("Video Camera", 13m, 1));
                order1.addItemToOrder(new Item("Mouse", 23m, 2));

                Order order2 = new Order("Alexandra");
                order2.addItemToOrder(new Item("Uscator Par", 40m, 1));
                order2.addItemToOrder(new Item("SSD-KD", 100m, 1));
                order2.addItemToOrder(new Item("ESP32-WROOM", 24m, 1));


                Order order3 = new Order("Mihai");
                order3.addItemToOrder(new Item("Night Lights", 13m, 4));


                Order order4 = new Order("Madaliana");
                order4.addItemToOrder(new Item("Minifrigider", 600m, 1));
                order4.addItemToOrder(new Item("SSD-KD", 50m, 1));


               
                OurShop ourShop = new OurShop();
                ourShop.addOrder(order1);
                ourShop.addOrder(order2);
                ourShop.addOrder(order3);
                ourShop.addOrder(order4);

                foreach(var x in ourShop.ourOrders)
                {
                    Console.WriteLine($"OrderID:{x.OrderID}, Customer:{x.CustomerName} = {x.CalculatePrice()} euro");

                }

                



                /////BEST CUSTOMER
                Console.WriteLine($"Best Customer: {ourShop.OurBestCustomer()}\n");


                ///// The popular products along with their total quantity sold.
                foreach (var x in ourShop.OurBestItemSold()) {
                    Console.WriteLine($"ItemName: {x.ItemName} -- sold: {x.ItemSales}" );
                }

            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
