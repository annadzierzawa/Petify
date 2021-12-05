using System.Collections.Generic;
using System.Linq;

namespace Petify.PublishedLanguage.Dtos.Advertisements
{
    public class AdvertisementSearchDTO : AdvertisementDTO
    {
        public string Description { get; set; }
        public string PetImageFileStorageIdsAsString { private get; set; }
        public List<string> PetImageFileStorageIds => PetImageFileStorageIdsAsString is not null ? PetImageFileStorageIdsAsString.Split(',').ToList() : new List<string>();

    }
}
