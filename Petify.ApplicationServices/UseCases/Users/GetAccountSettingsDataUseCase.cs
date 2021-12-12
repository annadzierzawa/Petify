using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Users;
using Petify.Common.Auth;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Dtos.Users;
using Petify.PublishedLanguage.Queries.Users;

namespace Petify.ApplicationServices.UseCases.Users
{
    public class GetAccountSettingsDataUseCase : IQueryHandler<GetAccountSettingsDataParameter, AccountSettingsDTO>
    {
        private readonly IUsersQuery _usersQuery;
        private readonly ICurrentUserService _currentUserService;

        public GetAccountSettingsDataUseCase(IUsersQuery usersQuery, ICurrentUserService currentUserService)
        {
            _usersQuery = usersQuery;
            _currentUserService = currentUserService;
        }

        public Task<AccountSettingsDTO> Handle(GetAccountSettingsDataParameter query)
        {
            return _usersQuery.GetAccountSettingsData(_currentUserService.UserId);
        }
    }
}
