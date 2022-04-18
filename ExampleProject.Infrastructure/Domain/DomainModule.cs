using Autofac;
using ExampleProject.Application.Customers.DomainServices;
using ExampleProject.Domain.Customers;
using ExampleProject.Domain.ForeignExchange;
using ExampleProject.Infrastructure.Domain.ForeignExchanges;

namespace ExampleProject.Infrastructure.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerUniquenessChecker>()
                .As<ICustomerUniquenessChecker>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ForeignExchange>()
                .As<IForeignExchange>()
                .InstancePerLifetimeScope();
        }
    }
}