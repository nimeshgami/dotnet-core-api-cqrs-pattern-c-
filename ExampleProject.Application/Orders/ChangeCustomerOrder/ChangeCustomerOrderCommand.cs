﻿using System;
using System.Collections.Generic;
using MediatR;
using ExampleProject.Application.Configuration.Commands;
using ExampleProject.Domain.Products;

namespace ExampleProject.Application.Orders.ChangeCustomerOrder
{
    public class ChangeCustomerOrderCommand : CommandBase<Unit>
    {
        public Guid CustomerId { get; }

        public Guid OrderId { get; }

        public string Currency { get; }

        public List<ProductDto> Products { get; }

        public ChangeCustomerOrderCommand(
            Guid customerId, 
            Guid orderId,
            List<ProductDto> products, 
            string currency)
        {
            this.CustomerId = customerId;
            this.OrderId = orderId;
            this.Currency = currency;
            this.Products = products;
        }
    }
}
