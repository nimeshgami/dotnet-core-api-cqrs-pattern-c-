using System;
using ExampleProject.Domain.SeedWork;

namespace ExampleProject.Domain.Products
{
    public class ProductId : TypedIdValueBase
    {
        public ProductId(Guid value) : base(value)
        {
        }
    }
}