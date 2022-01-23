using System;
using System.Collections.Generic;
using Weekday.model;

namespace Weekday.service
{
    public class OrderService
    {
        static int capacity = 7;
        private const int deliveryTimePerKm = 8;
        private Restaurant restaurant;

        public OrderService(Restaurant restaurant)
        {
            this.restaurant = restaurant;
        }

        public Dictionary<Order, decimal> GetDeliveryTimeByOrder(List<Order> order)
        {
            int requiredSlots = 0;
            decimal mealTime = 0;
            Dictionary<Order, decimal> deliveryTimeByOrder = new Dictionary<Order, decimal>();
            for (int i = 0; i < order.Count; i++)
            {
                mealTime = 0;
                requiredSlots = 0;
                foreach (MealType mealType in order[i].meals)
                {
                    if (mealType == MealType.A)
                    {
                        if (mealTime < restaurant.GetMealCookTime()[MealType.A])
                            mealTime = restaurant.GetMealCookTime()[MealType.A];
                        requiredSlots += restaurant.GetMealSlot()[MealType.A];
                    }
                    else
                    {
                        if (mealTime < restaurant.GetMealCookTime()[MealType.M])
                            mealTime = restaurant.GetMealCookTime()[MealType.M];
                        requiredSlots += restaurant.GetMealSlot()[MealType.M];
                    }
                }
                mealTime += (decimal)order[i].distance * deliveryTimePerKm;
                if (requiredSlots > restaurant.GetCapacity())
                {
                    deliveryTimeByOrder.Add(order[i], 0);
                }
                else if (requiredSlots <= capacity)
                {
                    if (mealTime < restaurant.GetMaxTimeForDeliver())
                    {
                        capacity -= requiredSlots;
                        restaurant.UpdateSlotByTime(mealTime, requiredSlots);
                        deliveryTimeByOrder.Add(order[i], mealTime);
                    }
                    else
                    {
                        deliveryTimeByOrder.Add(order[i], 0);
                    }

                }
                else
                {
                    int availableSlotCount = 0;
                    decimal waitingTime = 0, waitingTimeIndex = 0;
                    List<decimal> key = new List<decimal>();
                    var slotByWaitingTime = restaurant.GetSlotByWaitingTime();
                    foreach (var KeyValue in slotByWaitingTime)
                    {
                        key.Add(KeyValue.Key);
                        availableSlotCount += KeyValue.Value;
                        if (availableSlotCount >= requiredSlots)
                        {
                            waitingTime = KeyValue.Key;
                            break;
                        }
                    }
                    if (mealTime + waitingTime < restaurant.GetMaxTimeForDeliver())
                    {
                        deliveryTimeByOrder.Add(order[i], mealTime + waitingTime);
                        waitingTimeIndex = key.Count;
                        foreach (decimal k in key)
                        {
                            waitingTimeIndex--;
                            if (waitingTimeIndex == 0)
                            {
                                if (availableSlotCount - requiredSlots == 0)
                                {
                                    capacity += slotByWaitingTime[k];
                                    slotByWaitingTime.Remove(k);
                                }
                                else
                                {
                                    capacity += slotByWaitingTime[k] - (availableSlotCount - requiredSlots);
                                    slotByWaitingTime[k] = availableSlotCount - requiredSlots;
                                }
                            }
                            else
                            {
                                capacity += slotByWaitingTime[k];
                                slotByWaitingTime.Remove(k);
                            }
                        }
                        slotByWaitingTime.Add(mealTime + waitingTime, requiredSlots);
                        capacity -= requiredSlots;
                    }
                    else
                    {
                        deliveryTimeByOrder.Add(order[i], 0);
                    }
                }
            }
            return deliveryTimeByOrder;
        }
    }
}
