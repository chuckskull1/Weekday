using System;
using Weekday.model;
using Weekday.service;
using Weekday.service.Translator;
using System.Collections.Generic;

namespace Weekday.controller
{
    public class OrderController
    {
        private OrderService orderService;

        public Dictionary<Order,decimal> GetDeliveryTimeByOrder(string orders)
        {
            Restaurant restaurant = new Restaurant(7);
            orderService = new OrderService(restaurant);
            RequestOrderTranslator requestOrderTranslator = new RequestOrderTranslator();
            var ans = orderService.GetDeliveryTimeByOrder(requestOrderTranslator.GetOrderList(orders));
            return ans;
        }
    }
}
