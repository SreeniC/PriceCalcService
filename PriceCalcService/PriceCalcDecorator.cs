using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalcService
{
    /// <summary>
    /// Component Decorator class for calculating the price 
    /// </summary>
   public abstract class PriceCalcDecorator : ICalcService
    {
       ICalcService calcService;

       public PriceCalcDecorator(ICalcService calcService)
       {
           this.calcService = calcService;
       }

        public virtual decimal CalculatePrice()
        {
            return calcService.CalculatePrice();
        }
    }
}
