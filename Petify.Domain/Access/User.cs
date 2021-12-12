using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using EnsureThat;
using Petify.Domain.Advertisements;
using Petify.Domain.Common;
using Petify.Domain.Pets;

namespace Petify.Domain.Access
{
    public class User : FullyAuditableEntity
    {
        private User() { }

        public User(string userId, MailAddress email, string name, string phoneNumber)
        {
            EnsureArg.IsNotNullOrWhiteSpace(userId, nameof(userId));
            EnsureArg.IsNotNull(email, nameof(email));

            Id = userId;
            Email = email.Address;
            PhoneNumber = phoneNumber;
            IsActive = true;
            CreatedBy = "Init";
            SetName(name);
        }

        public void SetPersonalData(string name, string phoneNumber, string city = "")
        {
            EnsureArg.IsNotNullOrWhiteSpace(name, nameof(name));
            PhoneNumber = phoneNumber;
            City = city;
            SetName(name);
        }

        public void SetName(string name)
        {
            EnsureArg.IsNotNullOrWhiteSpace(name, nameof(name));
            Name = name;
        }

        public void UpdateAccountSettings(string name, string phoneNumber)
        {
            EnsureArg.IsNotNullOrWhiteSpace(name, nameof(name));
            EnsureArg.IsNotNullOrWhiteSpace(phoneNumber, nameof(phoneNumber));

            Name = name;
            PhoneNumber = phoneNumber;
        }

        public void DeactivateUser()
        {
            IsActive = false;
        }
        public void AddPet(Pet pet)
        {
            Pets.Add(pet);
        }

        public Pet GetPet(int id)
        {
            return Pets.FirstOrDefault(p => p.Id == id);
        }

        public Advertisement GetAdvertisement(int id)
        {
            return Advertisements.FirstOrDefault(a => a.Id == id);
        }

        public void DeletePet(Pet pet)
        {
            Pets.Remove(pet);
        }

        public void DeleteAdvertisement(Advertisement advertisement)
        {
            Advertisements.Remove(advertisement);
        }

        public void AddAdvertisement(Advertisement advertisement)
        {
            Advertisements.Add(advertisement);
        }

        public string Id { get; init; }
        public string Email { get; init; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string City { get; private set; }
        public bool IsActive { get; private set; }

        //navigation properties
        public List<Pet> Pets { get; set; }
        public List<Advertisement> Advertisements { get; set; }

    }
}