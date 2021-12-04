CREATE VIEW Advertisement.VW_AdvertisementsForSearch
AS
SELECT
	[Id],
	[Title],
	[Description],
	[AdvertisementTypeId],
	[StartDate],
	[EndDate],
	[CyclicalAssistanceFrequency],
	[OwnerId],
	(
		SELECT 
			STRING_AGG(pet.SpeciesId, ',')
		FROM 
			[dbo].[AdvertisementPet] ap
		JOIN 
			Pet.Pet pet ON ap.PetsId = pet.Id 
		WHERE
			ap.AdvertisementsId = ad.Id
	) AS SpeciesIdsAsString,
	(
		SELECT 
			STRING_AGG(pet.ImageFileStorageId, ',')
		FROM 
			[dbo].[AdvertisementPet] ap
		JOIN 
			Pet.Pet pet ON ap.PetsId = pet.Id 
		WHERE
			ap.AdvertisementsId = ad.Id
	) AS PetImageFileStorageIdsAsString
FROM Advertisement.Advertisement ad