using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PriceCalcService.Tests
{
    /// <summary>
    /// Unit test class for validating null, input data type. 
    /// Total price is calculated and validated after applying discount and state tax for each possible discount and state tax rates.
    /// </summary>
    [TestClass]
    public class CalcServiceTest
    {
        [TestMethod]
        public void ProductNullValueCheck_NotNull()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity=2, UnitPrice=500.0M };

            Assert.IsNotNull(product);
        }
        [TestMethod]
        public void ProductInputTypeCheck_Quantity_Integer()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity = 2, UnitPrice = 500.0M };

            Assert.AreEqual(product.Quantity.GetType(),typeof(int));
        }

        [TestMethod]
        public void ProductInputTypeCheck_UnitPrice_Decimal()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity = 2, UnitPrice = 500.0M };

            Assert.AreEqual(product.UnitPrice.GetType(), typeof(decimal));
        }

        [TestMethod]
        public void CalcServiceNullValueCheck_NotNull()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity = 2, UnitPrice = 500.0M };

            ICalcService calcService = new CalcService(product);

            Assert.IsNotNull(calcService);
        }

        [TestMethod]
        public void CalcDiscountServiceNullValueCheck_NotNull()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity = 3, UnitPrice = 500.0M };

            ICalcService calcService = new CalcService(product);
            ICalcService calcDiscountService = new PriceCalcDiscountDecorator(calcService);

            Assert.IsNotNull(calcDiscountService);
        }

        // Total price after Discount

        [TestMethod]
        public void CalcDiscountService_TotalPrice_3PercentDiscount()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity = 2, UnitPrice = 750.0M };

            ICalcService calcService = new CalcService(product);

            ICalcService calcDiscountService = new PriceCalcDiscountDecorator(calcService);
            decimal totalPrice = calcDiscountService.CalculatePrice();

            Assert.AreEqual(totalPrice,1455);
        }

        [TestMethod]
        public void CalcDiscountService_TotalPrice_5PercentDiscount()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity = 5, UnitPrice = 1000.0M };

            ICalcService calcService = new CalcService(product);

            ICalcService calcDiscountService = new PriceCalcDiscountDecorator(calcService);
            decimal totalPrice = calcDiscountService.CalculatePrice();

            Assert.AreEqual(totalPrice, 4750);
        }

        [TestMethod]
        public void CalcDiscountService_TotalPrice_7PercentDiscount()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity = 4, UnitPrice = 2100.0M };

            ICalcService calcService = new CalcService(product);

            ICalcService calcDiscountService = new PriceCalcDiscountDecorator(calcService);
            decimal totalPrice = calcDiscountService.CalculatePrice();

            Assert.AreEqual(totalPrice, 7812);
        }

        [TestMethod]
        public void CalcDiscountService_TotalPrice_10PercentDiscount()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity = 5, UnitPrice = 2100.0M };

            ICalcService calcService = new CalcService(product);

            ICalcService calcDiscountService = new PriceCalcDiscountDecorator(calcService);
            decimal totalPrice = calcDiscountService.CalculatePrice();

            Assert.AreEqual(totalPrice, 9450);
        }

        [TestMethod]
        public void CalcDiscountService_TotalPrice_15PercentDiscount()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity = 20, UnitPrice = 2550.0M };

            ICalcService calcService = new CalcService(product);

            ICalcService calcDiscountService = new PriceCalcDiscountDecorator(calcService);
            decimal totalPrice = calcDiscountService.CalculatePrice();

            Assert.AreEqual(totalPrice, 43350);
        }

        // Total price after Discount and State Tax

        [TestMethod]
        public void CalcStateTaxServiceNullValueCheck_NotNull()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity = 3, UnitPrice = 500.0M };

            ICalcService calcService = new CalcService(product);
            ICalcService calcDiscountService = new PriceCalcDiscountDecorator(calcService);

            ICalcService calcStateTaxService = new PriceCalcStateTaxDecorator(State.UT.ToString(), calcDiscountService);

            Assert.IsNotNull(calcStateTaxService);
        }

        [TestMethod]
        public void CalcDiscountService_TotalPrice_5PercentDiscount_StateUT()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity = 5, UnitPrice = 1000.0M };
            string stateCode = State.UT.ToString();

            ICalcService calcService = new CalcService(product);

            ICalcService calcDiscountService = new PriceCalcDiscountDecorator(calcService);
            decimal totalPrice = calcDiscountService.CalculatePrice();

            ICalcService calcStateTaxService = new PriceCalcStateTaxDecorator(stateCode, calcDiscountService);
            totalPrice = calcStateTaxService.CalculatePrice();

            Assert.AreEqual(totalPrice, decimal.Parse("5075.375"));
        }

        [TestMethod]
        public void CalcDiscountService_TotalPrice_7PercentDiscount_StateNV()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity = 6, UnitPrice = 1200.0M };
            string stateCode = State.NV.ToString();

            ICalcService calcService = new CalcService(product);

            ICalcService calcDiscountService = new PriceCalcDiscountDecorator(calcService);
            decimal totalPrice = calcDiscountService.CalculatePrice();

            ICalcService calcStateTaxService = new PriceCalcStateTaxDecorator(stateCode, calcDiscountService);
            totalPrice = calcStateTaxService.CalculatePrice();

            Assert.AreEqual(totalPrice, decimal.Parse("7231.68"));
        }

        [TestMethod]
        public void CalcDiscountService_TotalPrice_3PercentDiscount_StateTX()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity = 1, UnitPrice = 1200.0M };
            string stateCode = State.TX.ToString();

            ICalcService calcService = new CalcService(product);

            ICalcService calcDiscountService = new PriceCalcDiscountDecorator(calcService);
            decimal totalPrice = calcDiscountService.CalculatePrice();

            ICalcService calcStateTaxService = new PriceCalcStateTaxDecorator(stateCode, calcDiscountService);
            totalPrice = calcStateTaxService.CalculatePrice();

            Assert.AreEqual(totalPrice, decimal.Parse("1236.75"));
        }

        [TestMethod]
        public void CalcDiscountService_TotalPrice_15PercentDiscount_StateCA()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity = 22, UnitPrice = 2400.0M };
            string stateCode = State.CA.ToString();

            ICalcService calcService = new CalcService(product);

            ICalcService calcDiscountService = new PriceCalcDiscountDecorator(calcService);
            decimal totalPrice = calcDiscountService.CalculatePrice();

            ICalcService calcStateTaxService = new PriceCalcStateTaxDecorator(stateCode, calcDiscountService);
            totalPrice = calcStateTaxService.CalculatePrice();

            Assert.AreEqual(totalPrice, decimal.Parse("48582.6"));
        }

        [TestMethod]
        public void CalcDiscountService_TotalPrice_10PercentDiscount_StateAL()
        {
            Product product = new Product() { Type = ProductType.Bicycle, Quantity = 10, UnitPrice = 1200.0M };
            string stateCode = State.AL.ToString();

            ICalcService calcService = new CalcService(product);

            ICalcService calcDiscountService = new PriceCalcDiscountDecorator(calcService);
            decimal totalPrice = calcDiscountService.CalculatePrice();

            ICalcService calcStateTaxService = new PriceCalcStateTaxDecorator(stateCode, calcDiscountService);
            totalPrice = calcStateTaxService.CalculatePrice();

            Assert.AreEqual(totalPrice, decimal.Parse("11232"));
        }
    }
}
