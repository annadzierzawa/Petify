using System.Collections.Generic;
using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Advertisements;
using Petify.Infrastructure.QueryBuilder;
using Petify.PublishedLanguage.Dtos.Advertisements;

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
    }
}
