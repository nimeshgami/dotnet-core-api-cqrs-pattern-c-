using System.Threading.Tasks;

namespace ExampleProject.Infrastructure.Processing
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}