using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.OrderDecorator
{
    class LocalShipping : OrderDecorator
    {
        public LocalShipping(IOrder order) : base(order) { }

        public override double GetTotalPrice(double price)
        {
            return base.GetTotalPrice(price) + 2.5;
        }

        public int SetUpShippingTime(int importance) 
        {
            int shippingDays;
            if (importance == 1)
            {
                return 1;
            }
            else
            {
                shippingDays = 2 * importance;
            }
            return shippingDays;
        }
    }
}
