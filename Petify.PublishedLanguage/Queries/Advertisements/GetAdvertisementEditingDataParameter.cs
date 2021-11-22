using Petify.Common.CQRS;
using Petify.PublishedLanguage.Dtos.Advertisements;

namespace Petify.PublishedLanguage.Queries.Advertisements
{
    public class GetAdvertisementEditingDataParameter : IQuery<AdvertisementEditingDataDTO>
    {
        public int Id { get; set; }
    }
}
