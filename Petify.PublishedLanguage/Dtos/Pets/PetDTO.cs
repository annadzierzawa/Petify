using System;

namespace Petify.PublishedLanguage.Dtos.Pets
{
    public class PetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpeciesId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Description { get; set; }
        public string ImageFileStorageId { get; set; }
    }
}
