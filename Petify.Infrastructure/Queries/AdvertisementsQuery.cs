using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Advertisements;
using Petify.Common.Infrastructure.QueryBuilder;
using Petify.Infrastructure.QueryBuilder;
using Petify.PublishedLanguage.Dtos.Advertisements;
using Petify.PublishedLanguage.Queries.Advertisements;
using SRW_CRM.Infrastructure.QueryBuilder;

namespace Petify.Infrastructure.Queries
{
    public class AdvertisementsQuery : IAdvertisementsQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;

        public AdvertisementsQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public async Task<List<AdvertisementDTO>> GetAdvertisements(string userId)
        {
            return await _sqlQueryBuilder
               .SelectAllProperties<AdvertisementDTO>()
               .From("Advertisement.Advertisement")
               .Where("OwnerId", userId)
               .BuildQuery<AdvertisementDTO>()
               .ExecuteToList();
        }

        public async Task<AdvertisementEditingDataDTO> GetAdvertisementEditingData(int id)
        {
            return await _sqlQueryBuilder
              .SelectAllProperties<AdvertisementEditingDataDTO>("PetIDs")
              .From("Advertisement.VW_Advertisements")
              .Where("Id", id)
              .BuildQuery<AdvertisementEditingDataDTO>()
              .ExecuteToFirstElement();
        }

        public async Task<Page<AdvertisementSearchDTO>> GetAdvertisementsForSearch(GetAdvertisementsForSearchParameter query)
        {
            return await _sqlQueryBuilder
              .SelectAllProperties<AdvertisementSearchDTO>()
              .From("Advertisement.VW_Advertisements")
              .When(query.SpeciesIds.Any(), q => q.FilterInMultipleValues("SpeciesIdsAsString", query.SpeciesIds))
              .When(query.TypeIds.Any(), q => q.WhereIn("AdvertisementTypeId", query.TypeIds))
              .Where("EndDate", query.StartDate, SqlComparisonOperator.LessOrEqual)
              .BuildPagedQuery<AdvertisementSearchDTO>(query)
              .Execute();
        }
    }
}
