using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public interface IOrder
    {
        public double GetTotalPrice(double price);
    }
}
