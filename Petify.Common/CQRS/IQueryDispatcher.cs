using System.Threading.Tasks;

namespace Petify.Common.CQRS
{
    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TResult>(IQuery<TResult> query);
    }
}
