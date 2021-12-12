using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Users;
using Petify.PublishedLanguage.Dtos.Users;
using SRW_CRM.Infrastructure.QueryBuilder;

namespace Petify.Infrastructure.Queries
{
    public class UsersQuery : IUsersQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;

        public UsersQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public Task<AccountSettingsDTO> GetAccountSettingsData(string userId)
        {
            return _sqlQueryBuilder
                .SelectAllProperties<AccountSettingsDTO>()
                .From("Access.[User]")
                .Where("Id", userId)
                .BuildQuery<AccountSettingsDTO>()
                .ExecuteSingle();
        }
    }
}
