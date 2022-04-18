using System.Collections.Generic;
using ExampleProject.Application.Orders;

namespace ExampleProject.API.Orders
{
    public class CustomerOrderRequest
    {
        public List<ProductDto> Products { get; set; }

        public string Currency { get; set; }
    }
}