using System;
using System.Collections.Generic;
namespace Weekday.model
{
    public class Restaurant
    {
        private int capacity;
        private int freeSlots;
        private const int maxTimeForDelivery = 150;
        private SortedDictionary<decimal, int> slotByWaitingTime;
        private Dictionary<MealType, int> MealCookTime = new Dictionary<MealType, int> {
            {MealType.A, 17 },
            { MealType.M, 29}
        };
        private Dictionary<MealType, int> MealSlot = new Dictionary<MealType, int> {
            {MealType.A, 1 },
            { MealType.M, 2}
        };

        public Restaurant(int capacity)
        {
            this.capacity = capacity;
            freeSlots = capacity;
            slotByWaitingTime  = new SortedDictionary<decimal, int>();
        }

        public int GetFreeSlots()
        {
            return freeSlots;
        }

        public SortedDictionary<decimal, int> GetSlotByWaitingTime()
        {
            return slotByWaitingTime;
        }

        public int GetMaxTimeForDeliver()
        {
            return maxTimeForDelivery;
        }

        public Dictionary<MealType, int> GetMealCookTime()
        {
            return MealCookTime;
        }

        public Dictionary<MealType, int> GetMealSlot()
        {
            return MealSlot;
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public void AssignSlot()
        {

        }

        public void UpdateSlotByTime(decimal mealTime, int requiredSlots)
        {
            if (slotByWaitingTime.ContainsKey(mealTime))
            {
                slotByWaitingTime[mealTime] += requiredSlots;
            }
            else
            {
                slotByWaitingTime.Add(mealTime, requiredSlots);
            }
        }

        public decimal GetWaitingTime()
        {


            return 1;
        }
    }
}
