using System;
using System.Collections.Generic;
using Petify.Domain.Advertisements.Parameters;
using Petify.Domain.Common;
using Petify.Domain.Pets;

namespace Petify.Domain.Advertisements
{
    public class Advertisement : AuditableEntity
    {
        public Advertisement(string title,
            string description,
            int advertisementTypeId,
            List<Pet> pets,
            string ownerId,
            AdvertisementDatesParameter dates,
            List<CyclicalAssistanceDay> cyclicalAssistanceDays)
        {
            OwnerId = ownerId;
            SetDates(dates, cyclicalAssistanceDays);
            SetMainInformations(title, description, advertisementTypeId, pets);
        }

        private Advertisement() { }

        public void SetMainInformations(
            string title,
            string description,
            int advertisementTypeId,
            List<Pet> pets)
        {
            Title = title;
            Description = description;
            AdvertisementTypeId = advertisementTypeId;
            Pets = pets;
        }

        public void SetDates(AdvertisementDatesParameter dates,
            List<CyclicalAssistanceDay> cyclicalAssistanceDays)
        {
            StartDate = dates.StartDate;
            EndDate = dates.EndDate;
            CyclicalAssistanceDays = cyclicalAssistanceDays;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AdvertisementTypeId { get; set; }
        public int PetId { get; set; }
        public string OwnerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<CyclicalAssistanceDay> CyclicalAssistanceDays { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
