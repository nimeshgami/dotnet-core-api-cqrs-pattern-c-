﻿using System;
using MediatR;
using Newtonsoft.Json;
using ExampleProject.Application.Configuration.Commands;
using ExampleProject.Domain.Customers;

namespace ExampleProject.Application.Customers
{
    public class MarkCustomerAsWelcomedCommand : InternalCommandBase<Unit>
    {
        [JsonConstructor]
        public MarkCustomerAsWelcomedCommand(Guid id, CustomerId customerId) : base(id)
        {
            CustomerId = customerId;
        }

        public CustomerId CustomerId { get; }
    }
}