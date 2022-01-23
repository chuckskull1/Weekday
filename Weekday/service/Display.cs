using System;
using System.Collections.Generic;
using Weekday.model;
namespace Weekday.service
{
    public class Display
    {
        public void PrintOutput(Dictionary<Order,decimal> input)
        {
            foreach(var kv in input)
            {
                if (kv.Value == 0)
                    Console.WriteLine($"Order {kv.Key.orderId} is denied because the restaurant cannot accommodate it.");
                else
                    Console.WriteLine($"Order {kv.Key.orderId} will get delivered in {kv.Value} minutes");
            }
        }
    }
}
