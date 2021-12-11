using Petify.Common.CQRS;
using Petify.PublishedLanguage.Dtos.Advertisements;

namespace Petify.PublishedLanguage.Queries.Advertisements
{
    public class GetAdvertisementParameter : IQuery<AdvertisementDetailsDTO>
    {
        public int Id { get; set; }
    }
}
