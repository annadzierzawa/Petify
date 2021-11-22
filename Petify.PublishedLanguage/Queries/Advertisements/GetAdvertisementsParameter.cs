using System.Collections.Generic;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Dtos.Advertisements;

namespace Petify.PublishedLanguage.Queries.Advertisements
{
    public class GetAdvertisementsParameter : IQuery<List<AdvertisementDTO>>
    {
        public string UserId { get; set; }
    }
}
