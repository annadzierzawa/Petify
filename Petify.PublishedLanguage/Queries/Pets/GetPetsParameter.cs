using System.Collections.Generic;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Dtos.Pets;

namespace Petify.PublishedLanguage.Queries.Pets
{
    public class GetPetsParameter : IQuery<List<PetItemDTO>>
    {
        public string UserId { get; set; }
        public int? AdvertisementId { get; set; }
    }
}
