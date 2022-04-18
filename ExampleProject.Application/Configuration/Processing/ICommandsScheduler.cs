using System.Threading.Tasks;
using MediatR;
using ExampleProject.Application.Configuration.Commands;

namespace ExampleProject.Application.Configuration.Processing
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync<T>(ICommand<T> command);
    }
}