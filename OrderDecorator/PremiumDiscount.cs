using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.OrderDecorator
{
    class PremiumDiscount : OrderDecorator
    {
        public PremiumDiscount(IOrder order) : base(order) { }

        public override double GetTotalPrice(double price)
        {
            double withOutDiscount = base.GetTotalPrice(price);
            return withOutDiscount * 0.6;
        }
    }
}
