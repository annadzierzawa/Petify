using System;
using System.Collections.Generic;
using Petify.PublishedLanguage.Dtos.Pets;

namespace Petify.PublishedLanguage.Dtos.Advertisements
{
    public class AdvertisementDetailsDTO : AdvertisementDTO
    {
        public string Description { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string OwnerName { get; set; }
        public List<PetItemDTO> Pets { get; set; }
        public List<DateTime> CyclicalAssistanceDates { get; set; }
    }
}
