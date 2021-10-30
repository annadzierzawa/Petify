using System.Collections.Generic;
using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Pets;
using Petify.Infrastructure.QueryBuilder;
using Petify.PublishedLanguage.Dtos.Common;

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
    }
}
