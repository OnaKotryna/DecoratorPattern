using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    class PreOrder : IOrder
    {
        private double price;
        private int importance;
        public PreOrder(double price, int importance)
        {
            this.price = price;
            this.importance = importance;
        }

        public int GetImportance()
        {
            return importance;
        }

        public double GetPrice()
        {
            return price;
        }

        public double GetTotalPrice(double price)
        {
            return price * 0.7;
        }
    }
}
