using System.Reflection;
using ExampleProject.Application.Orders.PlaceCustomerOrder;

namespace ExampleProject.Infrastructure.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(PlaceCustomerOrderCommand).Assembly;
    }
}