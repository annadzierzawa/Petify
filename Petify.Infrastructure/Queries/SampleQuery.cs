using System.Collections.Generic;
using System.Threading.Tasks;
using EnsureThat;
using Petify.ApplicationServices.Boundaries;
using Petify.Infrastructure.QueryBuilder;
using Petify.PublishedLanguage.Dtos;
using Petify.PublishedLanguage.Queries;

namespace Petify.Infrastructure.Queries
{
    public class SampleQuery : ISampleQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;

        public SampleQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            EnsureArg.IsNotNull(sqlQueryBuilder, nameof(sqlQueryBuilder));

            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public async Task<List<SampleDTO>> GetSampleData(SampleParameter query)
        {
            return await _sqlQueryBuilder
                .Select("Name")
                .From("Sample")
                .BuildQuery<SampleDTO>()
                .ExecuteToList();
        }
    }
}
