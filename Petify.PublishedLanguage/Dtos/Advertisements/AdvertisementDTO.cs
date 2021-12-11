using System;

namespace Petify.PublishedLanguage.Dtos.Advertisements
{
    public class AdvertisementDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AdvertisementTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CyclicalAssistanceFrequency { get; set; }
    }
}
