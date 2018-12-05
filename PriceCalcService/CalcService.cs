using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalcService
{
    /// <summary>
    /// Component class for price calculation of products
    /// </summary>
    public interface ICalcService
    {
        decimal CalculatePrice();
    }
    /// <summary>
    /// Concrete component class for calculating price
    /// </summary>
    public class CalcService:ICalcService
    {
        Product product;

        public CalcService(Product product)
        {
            this.product = product;
        }

        public decimal CalculatePrice()
        {
            return product.Quantity * product.UnitPrice;
        }
    }
}
