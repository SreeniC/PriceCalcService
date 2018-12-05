using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalcService
{
   /// <summary>
   /// Concrete Component decorator class for calculating the price after adding State Tax 
   /// </summary>
    public class PriceCalcStateTaxDecorator : PriceCalcDecorator
    {
       string stateCode;

       public PriceCalcStateTaxDecorator(string stateCode, ICalcService calcService)
           : base(calcService)
       {
           this.stateCode = stateCode;            
       }

       public override decimal CalculatePrice()
       {
           decimal order = base.CalculatePrice();

           //Calculate price after State Tax
           if (stateCode != null)
           {
               switch (stateCode)
               {
                   case "AL": order += (order * Constants.TAX_AL / 100);
                       break;
                   case "CA": order += (order * Constants.TAX_CA / 100);
                       break;
                   case "NV": order += (order * Constants.TAX_NV / 100);
                       break;
                   case "TX": order += (order * Constants.TAX_TX / 100);
                       break;
                   case "UT": order += (order * Constants.TAX_UT / 100);
                       break;

                   default:
                       break;
               }
           }

           return order;
       }
    }
}
