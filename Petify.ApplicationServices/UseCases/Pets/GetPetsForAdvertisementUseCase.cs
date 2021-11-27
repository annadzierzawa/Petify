using System.Collections.Generic;
using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Pets;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Dtos.Pets;
using Petify.PublishedLanguage.Queries.Pets;

namespace Petify.ApplicationServices.UseCases.Pets
{
    public class GetPetsForAdvertisementUseCasee : IQueryHandler<GetPetsForAdvertisementParameter, List<PetAdvertisimentItemDTO>>
    {
        private readonly IPetsQuery _petsQuery;

        public GetPetsForAdvertisementUseCasee(IPetsQuery petsQuery)
        {
            _petsQuery = petsQuery;
        }

        public async Task<List<PetAdvertisimentItemDTO>> Handle(GetPetsForAdvertisementParameter query)
        {
            return await _petsQuery.GetPetsForAdvertisiment(query.UserId, query.AdvertisementId);
        }
    }
}
