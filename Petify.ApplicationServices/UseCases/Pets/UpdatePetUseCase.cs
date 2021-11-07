using System;
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
    public class UpdatePetUseCase : ICommandHandler<UpdatePetCommand>
    {
        private readonly IPetImagesMongoRepository _petImagesMongoRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePetUseCase(
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

        public async Task Handle(UpdatePetCommand command)
        {
            var user = await _usersRepository.GetUser(_currentUserService.UserId);
            var pet = user.GetPet(command.Id);
            string oldPetImageFileStorageId = "";

            if (!string.IsNullOrEmpty(command.Image))
            {
                if (!string.IsNullOrEmpty(pet.ImageFileStorageId))
                {
                    oldPetImageFileStorageId = pet.ImageFileStorageId;
                    pet.ResetImageFileStorageId();
                }
                var newImageMongoFileStorageId = await _petImagesMongoRepository.Insert("", Convert.FromBase64String(command.ImageAsValidBase64));
                pet.SetImageFileStorageId(newImageMongoFileStorageId.ToString());
            }

            pet.UpdateFields(command.Name, command.SpeciesId, command.DateOfBirth, command.Description);

            await _unitOfWork.Save();

            if (!string.IsNullOrEmpty(oldPetImageFileStorageId))
            {
                await _petImagesMongoRepository.Delete(new ObjectId(oldPetImageFileStorageId));
            }
        }
    }
}
