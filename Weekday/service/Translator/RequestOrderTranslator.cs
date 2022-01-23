using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Weekday.model;

namespace Weekday.service.Translator
{
    public class RequestOrderTranslator
    {
        private List<Order> orderList;

        public List<Order> GetOrderList(string order)
        {
            try
            {
                orderList = JsonConvert.DeserializeObject<List<Order>>(order);
                return orderList;
            }
            catch (Exception exception)
            {
                throw new Exception("Error during deserialization " + exception.Message);
            }
        }

    }
}
