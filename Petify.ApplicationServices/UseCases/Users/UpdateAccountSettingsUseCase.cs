using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Users;
using Petify.Common.Auth;
using Petify.Common.CQRS;
using Petify.Domain;
using Petify.PublishedLanguage.Commands.Users;

namespace Petify.ApplicationServices.UseCases.Users
{
    public class UpdateAccountSettingsUseCase : ICommandHandler<UpdateAccountSettingsCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public UpdateAccountSettingsUseCase(IUsersRepository usersRepository, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _usersRepository = usersRepository;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task Handle(UpdateAccountSettingsCommand command)
        {
            var user = await _usersRepository.GetUser(_currentUserService.UserId);

            user.UpdateAccountSettings(command.Name, command.PhoneNumber);

            await _unitOfWork.Save();
        }
    }
}
