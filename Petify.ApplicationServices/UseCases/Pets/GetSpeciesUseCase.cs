using System.Collections.Generic;
using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Pets;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Dtos.Common;
using Petify.PublishedLanguage.Queries.Pets;

namespace Petify.ApplicationServices.UseCases.Pets
{
    public class GetSpeciesUseCase : IQueryHandler<GetSpeciesParameter, List<LookupDTO>>
    {
        private readonly IPetsQuery _petsQuery;

        public GetSpeciesUseCase(IPetsQuery petsQuery)
        {
            _petsQuery = petsQuery;
        }

        public async Task<List<LookupDTO>> Handle(GetSpeciesParameter query)
        {
            return await _petsQuery.GetSpeciesLookup();
        }
    }
}
