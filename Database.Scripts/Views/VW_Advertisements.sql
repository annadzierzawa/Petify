CREATE VIEW [Advertisement].[VW_Advertisements]
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
			STRING_AGG(ap.PetsId, ',')
		FROM 
			[dbo].[AdvertisementPet] ap
		WHERE
			ap.AdvertisementsId = ad.Id
	) AS PetIDsAsString
FROM Advertisement.Advertisement ad