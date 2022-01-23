using System;
using Weekday.controller;
using Weekday.service;
namespace Weekday
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter list of orders: ");
            string orders = Console.ReadLine();
            OrderController orderController = new OrderController();
            var deliveryTimeByOrder = orderController.GetDeliveryTimeByOrder(orders);
            Display display = new Display();
            display.PrintOutput(deliveryTimeByOrder);
        }
    }
}
