using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Advertisements;
using Petify.Common.CQRS;
using Petify.Common.Infrastructure.QueryBuilder;
using Petify.PublishedLanguage.Dtos.Advertisements;
using Petify.PublishedLanguage.Queries.Advertisements;

namespace Petify.ApplicationServices.UseCases.Advertisements
{
    public class GetAdvertisementsForSearchUseCase : IQueryHandler<GetAdvertisementsForSearchParameter, Page<AdvertisementSearchDTO>>
    {
        private readonly IAdvertisementsQuery _advertisementsQuery;

        public GetAdvertisementsForSearchUseCase(IAdvertisementsQuery advertisementsQuery)
        {
            _advertisementsQuery = advertisementsQuery;
        }

        public async Task<Page<AdvertisementSearchDTO>> Handle(GetAdvertisementsForSearchParameter query)
        {
            return await _advertisementsQuery.GetAdvertisementsForSearch(query);
        }
    }
}
