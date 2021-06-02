using Decorator.OrderDecorator;
using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Esybės:");
            var order = new RegularOrder(20, 1);
            var preOrder = new PreOrder(20, 2);
            Console.WriteLine("  Regular order kaina (su PVM): " + order.GetTotalPrice(order.GetPrice()));
            Console.WriteLine("  PreOrder kaina (-30 %): " + preOrder.GetTotalPrice(preOrder.GetPrice()));

            Console.WriteLine("Dekoruotos esybės:");

            Console.WriteLine(" -Premium discount (-40 %):");
            var premiumDiscountOrder = new PremiumDiscount(order);
            var premiumDiscountPreOrder = new PremiumDiscount(preOrder);

            Console.WriteLine("    Regular order: " + premiumDiscountOrder.GetTotalPrice(order.GetPrice()));
            Console.WriteLine("    PreOrder: " + premiumDiscountPreOrder.GetTotalPrice(preOrder.GetPrice()));

            Console.WriteLine(" -PromoCode discount (-20 %):");

            var promoDiscountOrder = new PromoCodeDiscount(order);
            var promoDiscountPreOrder = new PromoCodeDiscount(preOrder);

            Console.WriteLine("    Regular order: " + promoDiscountOrder.GetTotalPrice(order.GetPrice()));
            Console.WriteLine("    PreOrder: " + String.Format("{0:0.00}", promoDiscountPreOrder.GetTotalPrice(preOrder.GetPrice())));

            Console.WriteLine(" -PreOrder with Local shipping + PromoCode Discount (-20 %):");

            var localPromoPreOrder = new LocalShipping( new PromoCodeDiscount(preOrder));
           
            Console.WriteLine("    Price: " + String.Format("{0:0.00}", localPromoPreOrder.GetTotalPrice(preOrder.GetPrice())));
            Console.WriteLine("    Shipping days: " + localPromoPreOrder.SetUpShippingTime(preOrder.GetImportance()));


            Console.WriteLine(" -RegularOrder with International Shipping + Premium Discount (-40 %) + PromoCode Discount (-20 %):");
            
            var interPremiumPromoOrder = new InternationalShipping( new PremiumDiscount( new PromoCodeDiscount(order)));

            Console.WriteLine("    Price: " + String.Format("{0:0.00}", interPremiumPromoOrder.GetTotalPrice(order.GetPrice())));
            Console.WriteLine("    Shipping days: " + interPremiumPromoOrder.SetUpShippingTime(order.GetImportance()));


            Console.WriteLine("Paieškos galimybė.\n Regular Order (price - 10) with PromoCode discount + Premium Discount + Local Shipping");
            var entity = new RegularOrder(10, 1);
            var decoratedEntity =  new PromoCodeDiscount( new PremiumDiscount( new LocalShipping(entity)));
            Console.WriteLine("  Price: " + String.Format("{0:0.00}", decoratedEntity.GetTotalPrice(entity.GetPrice())));
            Console.WriteLine(" Is there International shipping?");
            InternationalShipping withInternationalShipping = OrderDecorator.OrderDecorator.GetRole<InternationalShipping>(decoratedEntity);
            if(withInternationalShipping != null)
            {
                Console.WriteLine(" Yes");
                int shippingDays = withInternationalShipping.SetUpShippingTime(entity.GetImportance());
                Console.WriteLine("  Added shipping days: " + shippingDays);
            }
            else
            {
                Console.WriteLine("  No");
            }
            Console.WriteLine(" Is there Local shipping?");
            LocalShipping withLocalShipping = OrderDecorator.OrderDecorator.GetRole<LocalShipping>(decoratedEntity);
            if (withLocalShipping != null)
            {
                Console.WriteLine("  Yes");
                int shippingDays = withLocalShipping.SetUpShippingTime(entity.GetImportance());
                Console.WriteLine("  Added shipping days: " + shippingDays);
            }
            else
            {
                Console.WriteLine("  No");
            }

        }
    }
}
