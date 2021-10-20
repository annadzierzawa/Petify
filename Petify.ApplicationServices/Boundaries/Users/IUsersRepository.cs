using System.Threading.Tasks;

namespace Petify.ApplicationServices.Boundaries.Users
{
    public interface IUsersRepository
    {
        Task Store(Domain.Access.User user);
    }
}
