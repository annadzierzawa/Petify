using System.Threading.Tasks;
using Petify.Domain.Access;

namespace Petify.ApplicationServices.Boundaries.Users
{
    public interface IUsersRepository
    {
        Task Store(User user);
        Task<User> GetUser(string userId);
    }
}
