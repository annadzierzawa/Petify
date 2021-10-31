using Petify.Common.CQRS;

namespace Petify.PublishedLanguage.Queries.Pets
{
    public class GetPetImageParameter : IQuery<byte[]>
    {
        public string FileStorageId { get; set; }
    }
}
