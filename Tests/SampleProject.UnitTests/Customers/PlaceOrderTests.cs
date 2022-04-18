using System;
using System.Collections.Generic;
using NUnit.Framework;
using ExampleProject.Domain.Customers.Orders;
using ExampleProject.Domain.Customers.Orders.Events;
using ExampleProject.Domain.Customers.Rules;
using ExampleProject.Domain.ForeignExchange;
using ExampleProject.Domain.Products;
using ExampleProject.Domain.SharedKernel;
using ExampleProject.UnitTests.SeedWork;

namespace ExampleProject.UnitTests.Customers
{
    [TestFixture]
    public class PlaceOrderTests : TestBase
    {
        [Test]
        public void PlaceOrder_WhenAtLeastOneProductIsAdded_IsSuccessful()
        {
            // Arrange
            var customer = CustomerFactory.Create();

            var orderProductsData = new List<OrderProductData>();
            orderProductsData.Add(new OrderProductData(ExampleProducts.Product1Id, 2));
            
            var allProductPrices = new List<ProductPriceData>
            {
                ExampleProductPrices.Product1EUR, ExampleProductPrices.Product1USD
            };
            
            const string currency = "EUR";
            var conversionRates = GetConversionRates();
            
            // Act
            customer.PlaceOrder(
                orderProductsData, 
                allProductPrices, 
                currency, 
                conversionRates);

            // Assert
            var orderPlaced = AssertPublishedDomainEvent<OrderPlacedEvent>(customer);
            Assert.That(orderPlaced.Value, Is.EqualTo(MoneyValue.Of(200, "EUR")));
        }

        [Test]
        public void PlaceOrder_WhenNoProductIsAdded_BreaksOrderMustHaveAtLeastOneProductRule()
        {
            // Arrange
            var customer = CustomerFactory.Create();

            var orderProductsData = new List<OrderProductData>();

            var allProductPrices = new List<ProductPriceData>
            {
                ExampleProductPrices.Product1EUR, ExampleProductPrices.Product1USD
            };

            const string currency = "EUR";
            var conversionRates = GetConversionRates();

            // Assert
            AssertBrokenRule<OrderMustHaveAtLeastOneProductRule>(() =>
            {
                // Act
                customer.PlaceOrder(
                    orderProductsData,
                    allProductPrices,
                    currency,
                    conversionRates);
            });
        }

        [Test]
        public void PlaceOrder_GivenTwoOrdersInThatDayAlreadyMade_BreaksCustomerCannotOrderMoreThan2OrdersOnTheSameDayRule()
        {
            // Arrange
            var customer = CustomerFactory.Create();

            var orderProductsData = new List<OrderProductData>();
            orderProductsData.Add(new OrderProductData(ExampleProducts.Product1Id, 2));

            var allProductPrices = new List<ProductPriceData>
            {
                ExampleProductPrices.Product1EUR, ExampleProductPrices.Product1USD
            };

            const string currency = "EUR";
            var conversionRates = GetConversionRates();

            SystemClock.Set(new DateTime(2020, 1, 10, 11, 0, 0));
            customer.PlaceOrder(
                orderProductsData,
                allProductPrices,
                currency,
                conversionRates);

            SystemClock.Set(new DateTime(2020, 1, 10, 11, 30, 0));
            customer.PlaceOrder(
                orderProductsData,
                allProductPrices,
                currency,
                conversionRates);

            SystemClock.Set(new DateTime(2020, 1, 10, 12, 00, 0));

            // Assert
            AssertBrokenRule<CustomerCannotOrderMoreThan2OrdersOnTheSameDayRule>(() =>
            {
                // Act
                customer.PlaceOrder(
                    orderProductsData,
                    allProductPrices,
                    currency,
                    conversionRates);
            });
        }

        private static List<ConversionRate> GetConversionRates()
        {

            var conversionRates = new List<ConversionRate>();

            conversionRates.Add(new ConversionRate("USD", "EUR", (decimal)0.88));
            conversionRates.Add(new ConversionRate("EUR", "USD", (decimal)1.13));

            return conversionRates;
        }
    }



    public class ExampleProducts
    {
        public static readonly ProductId Product1Id = new ProductId(Guid.NewGuid());

        public static readonly ProductId Product2Id = new ProductId(Guid.NewGuid());
    }

    public class ExampleProductPrices
    {
        public static readonly ProductPriceData Product1EUR = new ProductPriceData(
            ExampleProducts.Product1Id,
            MoneyValue.Of(100, "EUR"));

        public static readonly ProductPriceData Product1USD = new ProductPriceData(
            ExampleProducts.Product1Id,
            MoneyValue.Of(110, "USD"));
    }
}