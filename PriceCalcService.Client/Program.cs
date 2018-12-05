using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalcService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string stateCode;

            Product product = new Product();

            Console.WriteLine(string.Format("Enter no. of {0}:",ProductType.Bicycle));
            product.Quantity = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Format("Enter Price/{0}:", ProductType.Bicycle));
            product.UnitPrice = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter State Code:");
            stateCode = Console.ReadLine();
            
            ICalcService calcService = new CalcService(product);

            Console.WriteLine("---------------------");

            //Total price after Discount
            ICalcService calcDiscountService = new PriceCalcDiscountDecorator(calcService);
            decimal totalPrice = calcDiscountService.CalculatePrice();

            Console.WriteLine("Total Price after discount: " + totalPrice);

            //Total price after Discount and State Tax
            ICalcService calcStateTaxService = new PriceCalcStateTaxDecorator(stateCode, calcDiscountService);
            totalPrice = calcStateTaxService.CalculatePrice();

            Console.WriteLine("Total Price after discount & Tax: " + totalPrice);

            Console.WriteLine("\nPress any key to Exit..");

            Console.ReadLine();
        }
    }
}
