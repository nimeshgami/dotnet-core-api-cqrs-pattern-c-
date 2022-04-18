using System;
using ExampleProject.Domain.SeedWork;

namespace ExampleProject.Domain.Customers.Orders
{
    public class OrderId : TypedIdValueBase
    {
        public OrderId(Guid value) : base(value)
        {
        }
    }
}