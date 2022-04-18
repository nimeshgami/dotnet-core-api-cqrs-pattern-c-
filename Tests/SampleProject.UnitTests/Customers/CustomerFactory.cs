using NSubstitute;
using ExampleProject.Domain.Customers;

namespace ExampleProject.UnitTests.Customers
{
    public class CustomerFactory
    {
        public static Customer Create()
        {
            var customerUniquenessChecker = Substitute.For<ICustomerUniquenessChecker>();
            var email = "customer@mail.com";
            customerUniquenessChecker.IsUnique(email).Returns(true);

            return Customer.CreateRegistered(email, "Name", customerUniquenessChecker);
        }
    }
}