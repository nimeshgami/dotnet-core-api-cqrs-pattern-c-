using Newtonsoft.Json;
using ExampleProject.Application.Configuration.DomainEvents;
using ExampleProject.Domain.Customers;
using ExampleProject.Domain.Customers.Orders;
using ExampleProject.Domain.Customers.Orders.Events;

namespace ExampleProject.Application.Orders.PlaceCustomerOrder
{
    public class OrderPlacedNotification : DomainNotificationBase<OrderPlacedEvent>
    {
        public OrderId OrderId { get; }
        public CustomerId CustomerId { get; }

        public OrderPlacedNotification(OrderPlacedEvent domainEvent) : base(domainEvent)
        {
            this.OrderId = domainEvent.OrderId;
            this.CustomerId = domainEvent.CustomerId;
        }

        [JsonConstructor]
        public OrderPlacedNotification(OrderId orderId, CustomerId customerId) : base(null)
        {
            this.OrderId = orderId;
            this.CustomerId = customerId;
        }
    }
}