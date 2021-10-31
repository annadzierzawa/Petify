using System.Collections.Generic;
using System.Net.Mail;
using EnsureThat;
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

        public void DeactivateUser()
        {
            IsActive = false;
        }
        public void AddPet(Pet pet)
        {
            Pets.Add(pet);
        }

        public string Id { get; init; }
        public string Email { get; init; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string City { get; private set; }
        public bool IsActive { get; private set; }

        //navigation properties
        public List<Pet> Pets { get; set; }

    }
}