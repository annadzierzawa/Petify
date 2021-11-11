using System;
using Petify.Common.CQRS;

namespace Petify.PublishedLanguage.Commands.Advertisements
{
    public class AddAdvertisementCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AdvertisementTypeId { get; set; }
        public int PetId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CyclicalAssistanceFrequency { get; set; }
    }
}
