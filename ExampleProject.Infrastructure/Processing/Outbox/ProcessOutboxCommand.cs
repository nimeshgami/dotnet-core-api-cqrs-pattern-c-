using MediatR;
using ExampleProject.Application;
using ExampleProject.Application.Configuration.Commands;

namespace ExampleProject.Infrastructure.Processing.Outbox
{
    public class ProcessOutboxCommand : CommandBase<Unit>, IRecurringCommand
    {

    }
}