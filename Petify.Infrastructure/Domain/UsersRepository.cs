using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Users;
using Petify.Domain.Access;
using Petify.Infrastructure.DataModel.Context;

namespace Petify.Infrastructure.Domain
{
    public class UsersRepository : IUsersRepository
    {
        private readonly PetifyContext _context;

        public UsersRepository(PetifyContext context)
        {
            _context = context;
        }

        public async Task Store(User user)
        {
            await _context.Users.AddAsync(user);
        }
    }
}
