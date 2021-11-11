using System;
using Petify.Domain.Common;

namespace Petify.Domain.Pets
{
    public class Pet : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpeciesId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Description { get; set; }
        public string ImageFileStorageId { get; set; }
        public string OwnerId { get; set; }
        private Pet() { }
        public Pet(string name, int speciesId, DateTime dateOfBirth, string description, string imageFileStorageId)
        {
            Name = name;
            SpeciesId = speciesId;
            DateOfBirth = dateOfBirth;
            Description = description;
            ImageFileStorageId = imageFileStorageId;
        }

        public void ResetImageFileStorageId()
        {
            ImageFileStorageId = string.Empty;
        }

        public void SetImageFileStorageId(string fileStorageId)
        {
            ImageFileStorageId = fileStorageId;
        }

        public void UpdateFields(string name, int speciesId, DateTime dateOfBirth, string description)
        {
            Name = name;
            SpeciesId = speciesId;
            DateOfBirth = dateOfBirth;
            Description = description;
        }
    }
}
