CREATE VIEW Advertisement.VW_PetsAdvertisements
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
	  ap.AdvertisementsId AdvertisementId
FROM
	  Pet.Pet pet
	  JOIN Lookup.SpeciesType speciesType ON pet.SpeciesId = speciesType.Id
	  JOIN dbo.AdvertisementPet ap ON ap.PetsId = pet.Id