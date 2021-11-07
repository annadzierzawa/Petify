using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Pets;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Dtos.Pets;
using Petify.PublishedLanguage.Queries.Pets;

namespace Petify.ApplicationServices.UseCases.Pets
{
    public class GetPetUseCase : IQueryHandler<GetPetParameter, PetDTO>
    {
        private readonly IPetsQuery _petsQuery;

        public GetPetUseCase(IPetsQuery petsQuery)
        {
            _petsQuery = petsQuery;
        }

        public async Task<PetDTO> Handle(GetPetParameter query)
        {
            return await _petsQuery.GetPet(query.Id);
        }
    }
}
