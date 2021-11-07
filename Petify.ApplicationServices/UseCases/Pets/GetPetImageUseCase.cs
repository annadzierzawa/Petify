using System.Threading.Tasks;
using MongoDB.Bson;
using Petify.Common.CQRS;
using Petify.FilesStorage.Repositories.PetImages;
using Petify.PublishedLanguage.Queries.Pets;

namespace Petify.ApplicationServices.UseCases.Pets
{
    public class GetPetImageUseCase : IQueryHandler<GetPetImageParameter, byte[]>
    {
        private readonly IPetImagesMongoRepository _petImagesMongoRepository;

        public GetPetImageUseCase(IPetImagesMongoRepository petImagesMongoRepository)
        {
            _petImagesMongoRepository = petImagesMongoRepository;
        }

        public async Task<byte[]> Handle(GetPetImageParameter query)
        {
            return await _petImagesMongoRepository.GetContentById(new ObjectId(query.FileStorageId));
        }
    }
}
