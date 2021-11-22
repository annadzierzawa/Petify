using System.Linq;
using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Users;
using Petify.Common.Auth;
using Petify.Common.CQRS;
using Petify.Domain;
using Petify.Domain.Services;
using Petify.PublishedLanguage.Commands.Advertisements;

namespace Petify.ApplicationServices.UseCases.Advertisements
{
    public class UpdateAdvertisementUseCase : ICommandHandler<UpdateAdvertisementCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IAdvertisementDatesService _advertisementDatesService;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAdvertisementUseCase(IUsersRepository usersRepository, ICurrentUserService currentUserService, IAdvertisementDatesService advertisementDatesService, IUnitOfWork unitOfWork)
        {
            _usersRepository = usersRepository;
            _currentUserService = currentUserService;
            _advertisementDatesService = advertisementDatesService;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateAdvertisementCommand command)
        {
            var user = await _usersRepository.GetUser(_currentUserService.UserId);
            var advertisement = user.GetAdvertisement(command.Id);
            var pets = command.PetIds.Select(id => user.GetPet(id)).ToList();

            advertisement.SetMainInformations(
                command.Title,
                command.Description,
                command.AdvertisementTypeId,
                pets,
                command.CyclicalAssistanceFrequency);

            advertisement.SetDates(
                _advertisementDatesService.GetAdvertisementDates(command.AdvertisementTypeId, command.StartDate, command.EndDate),
                _advertisementDatesService.GetCyclicalAssistanceDays(command.AdvertisementTypeId, command.StartDate, command.EndDate, command.CyclicalAssistanceFrequency));

            await _unitOfWork.Save();
        }
    }
}
