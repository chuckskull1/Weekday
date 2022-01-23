using System;
using System.Collections.Generic;
using Weekday.model;

namespace Weekday.model
{
    public class Order
    {
        public int orderId { get; set; }
        public List<MealType> meals { get; set; }
        public double distance { get; set; }
    }
}
