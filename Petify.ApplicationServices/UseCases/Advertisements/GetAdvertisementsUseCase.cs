using System.Collections.Generic;
using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Advertisements;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Dtos.Advertisements;
using Petify.PublishedLanguage.Queries.Advertisements;

namespace Petify.ApplicationServices.UseCases.Advertisements
{
    public class GetAdvertisementsUseCase : IQueryHandler<GetAdvertisementsParameter, List<AdvertisementDTO>>
    {
        private readonly IAdvertisementsQuery _advertisementsQuery;

        public GetAdvertisementsUseCase(IAdvertisementsQuery advertisementsQuery)
        {
            _advertisementsQuery = advertisementsQuery;
        }

        public async Task<List<AdvertisementDTO>> Handle(GetAdvertisementsParameter query)
        {
            return await _advertisementsQuery.GetAdvertisements(query.UserId);
        }
    }
}
