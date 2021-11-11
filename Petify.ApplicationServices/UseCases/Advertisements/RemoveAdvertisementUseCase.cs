using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Users;
using Petify.Common.Auth;
using Petify.Common.CQRS;
using Petify.Domain;
using Petify.PublishedLanguage.Commands.Advertisements;

namespace Petify.ApplicationServices.UseCases.Advertisements
{
    public class RemoveAdvertisementUseCase : ICommandHandler<RemoveAdvertisementCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveAdvertisementUseCase(IUsersRepository usersRepository, ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        {
            _usersRepository = usersRepository;
            _currentUserService = currentUserService;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveAdvertisementCommand command)
        {
            var user = await _usersRepository.GetUser(_currentUserService.UserId);
            var advertisement = user.GetAdvertisement(command.Id);
            user.DeleteAdvertisement(advertisement);

            await _unitOfWork.Save();
        }
    }
}
