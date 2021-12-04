using System;
using System.Collections.Generic;
using Petify.Common.CQRS;
using Petify.Common.Infrastructure.QueryBuilder;
using Petify.PublishedLanguage.Dtos.Advertisements;

namespace Petify.PublishedLanguage.Queries.Advertisements
{
    public class GetAdvertisementsForSearchParameter : SearchCriteria, IQuery<Page<AdvertisementSearchDTO>>
    {
        public List<int> TypeIds { get; set; }
        public List<int> SpeciesIds { get; set; }
        public DateTime StartDate { get; set; }
    }
}
