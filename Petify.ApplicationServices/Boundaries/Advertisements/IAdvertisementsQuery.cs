using System.Collections.Generic;
using System.Threading.Tasks;
using Petify.PublishedLanguage.Dtos.Advertisements;

namespace Petify.ApplicationServices.Boundaries.Advertisements
{
    public interface IAdvertisementsQuery
    {
        Task<List<AdvertisementDTO>> GetAdvertisements(string userId);
        Task<AdvertisementEditingDataDTO> GetAdvertisementEditingData(int id);
    }
}
