using System.Text;
using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Users;
using Petify.Common.Auth;
using Petify.Common.CQRS;
using Petify.Domain;
using Petify.Domain.Pets;
using Petify.FilesStorage.Repositories.PetImages;
using Petify.PublishedLanguage.Commands.Pets;

namespace Petify.ApplicationServices.UseCases.Pets
{
    public class AddPetUseCase : ICommandHandler<AddPetCommand>
    {
        private readonly IPetImagesMongoRepository _petImagesMongoRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;

        public AddPetUseCase(
            IPetImagesMongoRepository petImagesMongoRepository,
            IUsersRepository usersRepository,
            ICurrentUserService currentUserService,
            IUnitOfWork unitOfWork)
        {
            _petImagesMongoRepository = petImagesMongoRepository;
            _usersRepository = usersRepository;
            _currentUserService = currentUserService;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddPetCommand command)
        {
            var fileStorageId = "";
            if (!string.IsNullOrEmpty(command.Image))
            {
                var petImageMongoId = await _petImagesMongoRepository.Insert("", Encoding.ASCII.GetBytes(command.Image));
                fileStorageId = petImageMongoId.ToString();
            }
            var user = await _usersRepository.GetUser(_currentUserService.UserId);

            var pet = new Pet(command.Name, command.SpeciesId, command.DateOfBirth, command.Description, fileStorageId);

            user.AddPet(pet);

            await _unitOfWork.Save();
        }
    }
}
