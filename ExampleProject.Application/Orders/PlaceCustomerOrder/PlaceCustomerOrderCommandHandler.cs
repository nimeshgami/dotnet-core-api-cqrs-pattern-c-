﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExampleProject.Application.Configuration.Commands;
using ExampleProject.Application.Configuration.Data;
using ExampleProject.Domain.Customers;
using ExampleProject.Domain.Customers.Orders;
using ExampleProject.Domain.ForeignExchange;
using ExampleProject.Domain.Products;

namespace ExampleProject.Application.Orders.PlaceCustomerOrder
{
    public class PlaceCustomerOrderCommandHandler : ICommandHandler<PlaceCustomerOrderCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        
        private readonly IForeignExchange _foreignExchange;

        public PlaceCustomerOrderCommandHandler(
            ICustomerRepository customerRepository,
            IForeignExchange foreignExchange, 
            ISqlConnectionFactory sqlConnectionFactory)
        {
            this._customerRepository = customerRepository;
            this._foreignExchange = foreignExchange;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Guid> Handle(PlaceCustomerOrderCommand command, CancellationToken cancellationToken)
        {
            var customer = await this._customerRepository.GetByIdAsync(new CustomerId(command.CustomerId));

            var allProductPrices =
                await ProductPriceProvider.GetAllProductPrices(_sqlConnectionFactory.GetOpenConnection());

            var conversionRates = this._foreignExchange.GetConversionRates();

            var orderProductsData = command
                .Products
                .Select(x => new OrderProductData(new ProductId(x.Id), x.Quantity))
                .ToList();          
            
            var orderId = customer.PlaceOrder(
                orderProductsData,
                allProductPrices,
                command.Currency,
                conversionRates);

            return orderId.Value;
        }
    }
}