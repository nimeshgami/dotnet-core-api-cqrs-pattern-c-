using ExampleProject.Domain.SeedWork;

namespace ExampleProject.Domain.Customers
{
    public class CustomerRegisteredEvent : DomainEventBase
    {
        public CustomerId CustomerId { get; }

        public CustomerRegisteredEvent(CustomerId customerId)
        {
            this.CustomerId = customerId;
        }
    }
}