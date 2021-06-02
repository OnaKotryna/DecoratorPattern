using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.OrderDecorator
{
    class InternationalShipping : OrderDecorator
    {
        public InternationalShipping(IOrder order) : base(order) { }

        public override double GetTotalPrice(double price)
        {
            return base.GetTotalPrice(price) + 50;
        }

        public int SetUpShippingTime(int importance)
        {
            int shippingDays;
            if(importance == 1)
            {
                return 2;
            } 
            else
            {
                shippingDays = 7 * importance;
            }
            return shippingDays;
        }
    }
}
