using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Pets;
using Petify.PublishedLanguage.Dtos.Common;
using Petify.PublishedLanguage.Dtos.Pets;
using SRW_CRM.Infrastructure.QueryBuilder;

namespace Petify.Infrastructure.Queries
{
    public class PetsQuery : IPetsQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;

        public PetsQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public async Task<List<LookupDTO>> GetSpeciesLookup()
        {
            return await _sqlQueryBuilder
               .SelectAllProperties<LookupDTO>()
               .From("Lookup.SpeciesType")
               .BuildQuery<LookupDTO>()
               .ExecuteToList();
        }

        public async Task<PetDTO> GetPet(int id)
        {
            return await _sqlQueryBuilder
              .SelectAllProperties<PetDTO>()
              .From("Pet.Pet")
              .Where("Id", id)
              .BuildQuery<PetDTO>()
              .ExecuteSingle();
        }

        public async Task<List<PetItemDTO>> GetPets(string userId)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<PetItemDTO>("Age")
                .From("Pet.VW_PetItems")
                .Where("OwnerId", userId)
                .BuildQuery<PetItemDTO>()
                .ExecuteToList();
        }

        public async Task<List<PetAdvertisimentItemDTO>> GetPetsForAdvertisiment(string userId, int advertisementId)
        {
            var petsInAdvertisement = await _sqlQueryBuilder
                .SelectAllProperties<PetAdvertisimentQueryItem>("Age")
                .From("Advertisement.VW_PetsAdvertisements")
                .Where("OwnerId", userId)
                .BuildQuery<PetAdvertisimentQueryItem>()
                .ExecuteToList();

            var result = petsInAdvertisement
                .GroupBy(
                pet => new { pet.Id, pet.Name, pet.SpeciesId, pet.DateOfBirth, pet.Description, pet.ImageFileStorageId, pet.SpeciesName },
                pet => pet,
                (pet, pets) => new PetAdvertisimentItemDTO
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    SpeciesId = pet.SpeciesId,
                    SpeciesName = pet.SpeciesName,
                    DateOfBirth = pet.DateOfBirth,
                    Description = pet.Description,
                    ImageFileStorageId = pet.ImageFileStorageId,
                    IsChecked = pets.Any(p => p.AdvertisementId == advertisementId)
                }
                ).ToList();

            return result;
        }
    }
}
