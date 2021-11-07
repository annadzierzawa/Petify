using MongoDB.Driver.GridFS;
using Petify.FilesStorage.Context;
using Petify.FilesStorage.Repositories.BaseRepositories;

namespace Petify.FilesStorage.Repositories.PetImages
{
    public class PetImagesMongoRepository : GridFsRepository, IPetImagesMongoRepository
    {
        public PetImagesMongoRepository(MongoDbContext context)
            : base(context, new GridFSBucketOptions { BucketName = "PetImages" })
        {
        }
    }
}
