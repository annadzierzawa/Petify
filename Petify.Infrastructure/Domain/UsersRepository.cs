using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<User> GetUser(string userId)
        {
            var user = await _context.Users
                .Include(u => u.Pets)
                .Include(u => u.Advertisements).ThenInclude(a => a.Dates)
                .Include(u => u.Advertisements).ThenInclude(a => a.CyclicalAssistanceDays)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user is null)
            {
                throw new Exception($"User with Id {userId} not found");
            }

            return user;
        }

        public async Task Store(User user)
        {
            await _context.Users.AddAsync(user);
        }
    }
}
