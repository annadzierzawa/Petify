CREATE VIEW Pet.VW_PetsWithAdvertisements
AS
SELECT
	  pet.[Id],
	  pet.[Name],
	  pet.[SpeciesId],
	  pet.[DateOfBirth],
	  pet.[Description],
	  pet.[OwnerId],
	  pet.[CreatedBy],
	  pet.[CreatedOn],
	  pet.[UpdatedBy],
	  pet.[UpdatedOn],
	  pet.[ImageFileStorageId],
	  speciesType.[Name] AS SpeciesName,
	  ap.AdvertisementsId AS AdvertisementId
FROM
	  Pet.VW_PetItems pet
	  JOIN Lookup.SpeciesType speciesType ON pet.SpeciesId = speciesType.Id
	  JOIN dbo.AdvertisementPet ap ON ap.PetsId = pet.Id