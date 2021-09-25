using System.Threading.Tasks;

namespace Petify.Common.CQRS
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
