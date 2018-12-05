using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalcService
{
    public class Constants
    {
        public const decimal TAX_UT = 6.85M;
        public const decimal TAX_NV = 8.00M;
        public const decimal TAX_TX = 6.25M;
        public const decimal TAX_AL = 4.00M;
        public const decimal TAX_CA = 8.25M;

        public const decimal ORDER_1000 = 1000M;
        public const decimal ORDER_5000 = 5000M;
        public const decimal ORDER_7000 = 7000M;
        public const decimal ORDER_10000 = 10000M;
        public const decimal ORDER_50000 = 50000M;

        public const int DISCOUNT_1000 = 3;
        public const int DISCOUNT_5000 = 5;
        public const int DISCOUNT_7000 = 7;
        public const int DISCOUNT_10000 = 10;
        public const int DISCOUNT_50000 = 15;
    }

    public enum State
    {
        UT,
        NV,
        TX,
        AL,
        CA
    } 

    public enum ProductType
    {
        Bicycle
    } 
}
