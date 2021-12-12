using System.Threading.Tasks;
using Petify.PublishedLanguage.Dtos.Users;

namespace Petify.ApplicationServices.Boundaries.Users
{
    public interface IUsersQuery
    {
        public Task<AccountSettingsDTO> GetAccountSettingsData(string userId);
    }
}
