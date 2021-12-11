using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Advertisements;
using Petify.Common.Infrastructure.QueryBuilder;
using Petify.Infrastructure.QueryBuilder;
using Petify.PublishedLanguage.Dtos.Advertisements;
using Petify.PublishedLanguage.Dtos.Pets;
using Petify.PublishedLanguage.Queries.Advertisements;
using SRW_CRM.Infrastructure.QueryBuilder;
using static Petify.Common.Lookups.AdvertisementTypeLookup;

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

        public async Task<AdvertisementDetailsDTO> GetAdvertisement(int id)
        {
            var result = await _sqlQueryBuilder
              .SelectAllProperties<AdvertisementDetailsDTO>("Pets", "CyclicalAssistanceDates")
              .From("Advertisement.VW_AdvertisementsDetails")
              .Where("Id", id)
              .BuildQuery<AdvertisementDetailsDTO>()
              .ExecuteSingle();

            result.Pets = await _sqlQueryBuilder
                .SelectAllProperties<PetItemDTO>("Age")
                .From("Pet.VW_PetsWithAdvertisements")
                .Where("AdvertisementId", id)
                .BuildQuery<PetItemDTO>()
                .ExecuteToList();

            if (result.AdvertisementTypeId == (int)AdvertisementTypeEnum.CyclicalAssistance)
            {
                result.CyclicalAssistanceDates = await _sqlQueryBuilder
                    .Select("Date")
                    .From("Advertisement.CyclicalAssistanceDay")
                    .Where("AdvertisementId", id)
                    .BuildQuery<DateTime>()
                    .ExecuteToList();
            }

            return result;
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
              .SelectAllProperties<AdvertisementSearchDTO>("PetImageFileStorageIds")
              .From("Advertisement.VW_AdvertisementsForSearch")
              .When(query.SpeciesIds is not null && query.SpeciesIds.Any(), q => SearchByTagsOr(q, "SpeciesIdsAsString", query.SpeciesIds))
              .When(query.TypeIds is not null && query.TypeIds.Any(), q => SearchByTagsOr(q, "AdvertisementTypeId", query.TypeIds))
              .When(query.TypeIds is null, q => q.Where("AdvertisementTypeId", ((int)AdvertisementTypeEnum.Adoption).ToString(), SqlComparisonOperator.NotLike))
              .Where("EndDate", query.StartDate, SqlComparisonOperator.GreaterOrEqual)
              .BuildPagedQuery<AdvertisementSearchDTO>(query)
              .Execute();
        }

        private static SqlQueryBuilder SearchByTagsOr<T>(SqlQueryBuilder builder, string columnName, List<T> searchvalues)
        {
            var tags = searchvalues.Select(x => x.ToString());

            IEnumerable<string> columns = tags.Select(x => columnName);
            IEnumerable<ValueToFilter> values = tags.Select(tag => ValueToFilter.IsLike(tag));

            builder.WhereMultipleOrConditions(columns.ToArray(), values.ToArray());

            return builder;
        }
    }
}
