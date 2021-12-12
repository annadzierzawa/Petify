using Petify.Common.CQRS;
using Petify.PublishedLanguage.Dtos.Users;

namespace Petify.PublishedLanguage.Queries.Users
{
    public class GetAccountSettingsDataParameter : IQuery<AccountSettingsDTO>
    {
    }
}
