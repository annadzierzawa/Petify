using System;
using System.Collections.Generic;
using System.Linq;
using Petify.Domain.Access;
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
            int? cyclicalAssistanceFrequency,
            AdvertisementDatesParameter dates,
            List<CyclicalAssistanceDay> cyclicalAssistanceDays)
        {
            OwnerId = ownerId;
            SetDates(dates, cyclicalAssistanceDays);
            SetMainInformations(title, description, advertisementTypeId, cyclicalAssistanceFrequency);

            Pets = new List<Pet>();
            SetPets(pets);
        }

        private Advertisement() { }

        public void SetMainInformations(
            string title,
            string description,
            int advertisementTypeId,
            int? cyclicalAssistanceFrequency)
        {
            Title = title;
            Description = description;
            AdvertisementTypeId = advertisementTypeId;
            CyclicalAssistanceFrequency = cyclicalAssistanceFrequency;
        }

        public void SetPets(List<Pet> pets)
        {
            var petsToRemove = Pets.Where(p => !pets.Any(pet => pet.Id == p.Id)).ToList();

            foreach (var pet in petsToRemove)
            {
                Pets.Remove(pet);
            }

            var petsToAdd = pets.Where(p => !Pets.Any(pet => pet.Id == p.Id)).ToList();

            Pets.AddRange(petsToAdd);
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
        public string OwnerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CyclicalAssistanceFrequency { get; set; }
        public User Owner { get; set; }
        public List<CyclicalAssistanceDay> CyclicalAssistanceDays { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
