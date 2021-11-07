using System.Threading.Tasks;
using MongoDB.Bson;
using Petify.ApplicationServices.Boundaries.Users;
using Petify.Common.Auth;
using Petify.Common.CQRS;
using Petify.Domain;
using Petify.FilesStorage.Repositories.PetImages;
using Petify.PublishedLanguage.Commands.Pets;

namespace Petify.ApplicationServices.UseCases.Pets
{
    public class RemovePetUseCase : ICommandHandler<RemovePetCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPetImagesMongoRepository _petImagesMongoRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly ICurrentUserService _currentUserService;

        public RemovePetUseCase(
            IUnitOfWork unitOfWork,
            IPetImagesMongoRepository petImagesMongoRepository,
            IUsersRepository usersRepository,
            ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _petImagesMongoRepository = petImagesMongoRepository;
            _currentUserService = currentUserService;
            _usersRepository = usersRepository;
        }

        public async Task Handle(RemovePetCommand command)
        {
            var user = await _usersRepository.GetUser(_currentUserService.UserId);
            var pet = user.GetPet(command.Id);

            user.DeletePet(pet);

            await _unitOfWork.Save();

            if (!string.IsNullOrEmpty(pet.ImageFileStorageId))
            {
                await _petImagesMongoRepository.Delete(new ObjectId(pet.ImageFileStorageId));
            }
        }
    }
}
