using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    class RegularOrder : IOrder
    {
        private double price;
        private int importance;

        public RegularOrder(double price, int importance)
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
            return price + price * 0.21;
        }

    }
}
