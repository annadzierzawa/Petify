using System.Collections.Generic;
using System.Threading.Tasks;
using Petify.Common.Infrastructure.QueryBuilder;
using Petify.PublishedLanguage.Dtos.Advertisements;
using Petify.PublishedLanguage.Queries.Advertisements;

namespace Petify.ApplicationServices.Boundaries.Advertisements
{
    public interface IAdvertisementsQuery
    {
        Task<List<AdvertisementDTO>> GetAdvertisements(string userId);
        Task<AdvertisementEditingDataDTO> GetAdvertisementEditingData(int id);
        Task<Page<AdvertisementSearchDTO>> GetAdvertisementsForSearch(GetAdvertisementsForSearchParameter query);
    }
}
