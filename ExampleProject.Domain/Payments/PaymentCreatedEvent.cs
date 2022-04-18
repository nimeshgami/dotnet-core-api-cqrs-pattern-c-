using System;
using ExampleProject.Domain.Customers.Orders;
using ExampleProject.Domain.SeedWork;

namespace ExampleProject.Domain.Payments
{
    public class PaymentCreatedEvent : DomainEventBase
    {
        public PaymentCreatedEvent(PaymentId paymentId, OrderId orderId)
        {
            this.PaymentId = paymentId;
            this.OrderId = orderId;
        }

        public PaymentId PaymentId { get; }

        public OrderId OrderId { get; }
    }
}