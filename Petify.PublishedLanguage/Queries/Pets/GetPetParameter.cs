using Petify.Common.CQRS;
using Petify.PublishedLanguage.Dtos.Pets;

namespace Petify.PublishedLanguage.Queries.Pets
{
    public class GetPetParameter : IQuery<PetDTO>
    {
        public int Id { get; set; }
    }
}
