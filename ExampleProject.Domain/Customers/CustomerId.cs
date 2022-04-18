using System;
using ExampleProject.Domain.SeedWork;

namespace ExampleProject.Domain.Customers
{
    public class CustomerId : TypedIdValueBase
    {
        public CustomerId(Guid value) : base(value)
        {
        }
    }
}