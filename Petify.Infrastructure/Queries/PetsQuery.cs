using System.Collections.Generic;
using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Pets;
using Petify.Infrastructure.QueryBuilder;
using Petify.PublishedLanguage.Dtos.Common;
using Petify.PublishedLanguage.Dtos.Pets;

namespace Petify.Infrastructure.Queries
{
    public class PetsQuery : IPetsQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;

        public PetsQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public async Task<List<LookupDTO>> GetSpeciesLookup()
        {
            return await _sqlQueryBuilder
               .SelectAllProperties<LookupDTO>()
               .From("Lookup.SpeciesType")
               .BuildQuery<LookupDTO>()
               .ExecuteToList();
        }

        public async Task<PetDTO> GetPet(int id)
        {
            return await _sqlQueryBuilder
              .SelectAllProperties<PetDTO>()
              .From("Pet.Pet")
              .BuildQuery<PetDTO>()
              .ExecuteSingle();
        }

        public async Task<List<PetItemDTO>> GetPets(string userId)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<PetItemDTO>("Age")
                .From("Pet.VW_PetItems")
                .BuildQuery<PetItemDTO>()
                .ExecuteToList();
        }
    }
}
