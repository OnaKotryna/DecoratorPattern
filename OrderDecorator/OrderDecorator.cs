using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.OrderDecorator
{
    public abstract class OrderDecorator : IOrder
    {
        private IOrder order;

        public OrderDecorator(IOrder order)
        {
            this.order = order;
        }

        public virtual double GetTotalPrice(double price)
        {
            return order.GetTotalPrice(price);
        }

        public IOrder GetOrder()
        {
            return order;
        }

        public static T GetRole<T>(IOrder o) where T: OrderDecorator
        {
            try
            {
                if(o is T){
                    return (T)o;
                }
                else
                {
                    T role = GetRole<T>(((OrderDecorator)o).GetOrder());
                    return role;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

    }
}
