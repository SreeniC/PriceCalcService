using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalcService
{
    /// <summary>
    /// Concrete Component decorator class for calculating the price after applying discount 
    /// </summary>
    public class PriceCalcDiscountDecorator : PriceCalcDecorator
    {
        public PriceCalcDiscountDecorator(ICalcService calcService)
            : base(calcService)
        {
        }

        public override decimal CalculatePrice()
        {
            decimal order = base.CalculatePrice();

            order = PriceAfterDiscount(order);
 
            return order;
        }

        private static decimal PriceAfterDiscount(decimal order)
        {
            //Order - $1000 ; Discount - 3%
            if (order >= Constants.ORDER_1000 && order < Constants.ORDER_5000)
            {
                order -= (order * Constants.DISCOUNT_1000 / 100);
            }

            //Order - $5000 ; Discount - 5%
            if (order >= Constants.ORDER_5000 && order < Constants.ORDER_7000)
            {
                 order -= (order * Constants.DISCOUNT_5000 / 100);
            }

            //Order - $7000 ; Discount - 7%
            if (order >= Constants.ORDER_7000 && order < Constants.ORDER_10000)
            {
                 order -= (order * Constants.DISCOUNT_7000 / 100);
            }

            //Order - $10000 ; Discount - 10%
            if (order >= Constants.ORDER_10000 && order < Constants.ORDER_50000)
            {
                 order -= (order * Constants.DISCOUNT_10000 / 100);
            }

            //Order - $50000 ; Discount - 15%
            if (order >= Constants.ORDER_50000)
            {
                 order -= (order * Constants.DISCOUNT_50000 / 100);
            }
            return order;
        }
    }
}
