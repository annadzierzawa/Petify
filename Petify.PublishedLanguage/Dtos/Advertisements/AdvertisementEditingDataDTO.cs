using System;
using System.Collections.Generic;
using System.Linq;

namespace Petify.PublishedLanguage.Dtos.Advertisements
{
    public class AdvertisementEditingDataDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AdvertisementTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CyclicalAssistanceFrequency { get; set; }
        public List<int> PetIDs => PetIDsAsString != null ? PetIDsAsString.Split(',').Select(c => int.Parse(c)).ToList() : new List<int>();
        public string PetIDsAsString { get; set; }
    }
}
