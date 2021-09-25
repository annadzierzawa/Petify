using System.Threading.Tasks;

namespace Petify.Domain
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}
