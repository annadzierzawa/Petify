using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Advertisements;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Dtos.Advertisements;
using Petify.PublishedLanguage.Queries.Advertisements;

namespace Petify.ApplicationServices.UseCases.Advertisements
{
    public class GetAdvertisementUseCase : IQueryHandler<GetAdvertisementParameter, AdvertisementDetailsDTO>
    {
        private readonly IAdvertisementsQuery _advertisementsQuery;

        public GetAdvertisementUseCase(IAdvertisementsQuery advertisementsQuery)
        {
            _advertisementsQuery = advertisementsQuery;
        }

        public async Task<AdvertisementDetailsDTO> Handle(GetAdvertisementParameter query)
        {
            return await _advertisementsQuery.GetAdvertisement(query.Id);
        }
    }
}
