using MediatR;
using ExampleProject.Application;
using ExampleProject.Application.Configuration.Commands;
using ExampleProject.Infrastructure.Processing.Outbox;

namespace ExampleProject.Infrastructure.Processing.InternalCommands
{
    internal class ProcessInternalCommandsCommand : CommandBase<Unit>, IRecurringCommand
    {

    }
}