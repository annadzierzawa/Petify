using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Advertisements;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Dtos.Advertisements;
using Petify.PublishedLanguage.Queries.Advertisements;

namespace Petify.ApplicationServices.UseCases.Advertisements
{
    public class GetAdvertisementEditingDataUseCase : IQueryHandler<GetAdvertisementEditingDataParameter, AdvertisementEditingDataDTO>
    {
        private readonly IAdvertisementsQuery _advertisementsQuery;

        public GetAdvertisementEditingDataUseCase(IAdvertisementsQuery advertisementsQuery)
        {
            _advertisementsQuery = advertisementsQuery;
        }

        public async Task<AdvertisementEditingDataDTO> Handle(GetAdvertisementEditingDataParameter query)
        {
            return await _advertisementsQuery.GetAdvertisementEditingData(query.Id);
        }
    }
}
