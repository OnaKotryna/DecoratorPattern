using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.OrderDecorator
{
    class PromoCodeDiscount : OrderDecorator
    {
        public PromoCodeDiscount(IOrder order) : base(order) { }

        public override double GetTotalPrice(double price)
        {
            double withOutDiscount = base.GetTotalPrice(price);
            return withOutDiscount * 0.8;
        }
    }
}
