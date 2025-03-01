﻿using System;
using System.Collections.Generic;
using MediatR;
using ExampleProject.Application.Configuration.Commands;

namespace ExampleProject.Application.Orders.PlaceCustomerOrder
{
    public class PlaceCustomerOrderCommand : CommandBase<Guid>
    {
        public Guid CustomerId { get; }

        public List<ProductDto> Products { get; }

        public string Currency { get; }

        public PlaceCustomerOrderCommand(
            Guid customerId, 
            List<ProductDto> products, 
            string currency)
        {
            this.CustomerId = customerId;
            this.Products = products;
            this.Currency = currency;
        }
    }
}