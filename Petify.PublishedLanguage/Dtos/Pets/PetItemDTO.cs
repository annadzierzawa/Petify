using System;

namespace Petify.PublishedLanguage.Dtos.Pets
{
    public class PetItemDTO : PetDTO
    {
        public string SpeciesName { get; set; }
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var ageInMonths = ((today.Year - DateOfBirth.Year) * 12) + today.Month - DateOfBirth.Month;
                return ageInMonths;
            }
        }
    }
}
