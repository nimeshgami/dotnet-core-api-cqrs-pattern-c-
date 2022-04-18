using System;
using System.Threading.Tasks;

namespace ExampleProject.Infrastructure.Processing
{
    public interface ICommandsDispatcher
    {
        Task DispatchCommandAsync(Guid id);
    }
}
