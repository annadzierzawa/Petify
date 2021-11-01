using System.Collections.Generic;
using System.Threading.Tasks;
using Petify.PublishedLanguage.Dtos.Common;
using Petify.PublishedLanguage.Dtos.Pets;

namespace Petify.ApplicationServices.Boundaries.Pets
{
    public interface IPetsQuery
    {
        Task<List<LookupDTO>> GetSpeciesLookup();
        Task<PetDTO> GetPet(int id);
        Task<List<PetItemDTO>> GetPets(string userId);
    }
}
