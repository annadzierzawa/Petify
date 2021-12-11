CREATE VIEW Advertisement.VW_AdvertisementsDetails
AS
SELECT ad.[Id],
		ad.[Title],
		ad.[Description],
		ad.[AdvertisementTypeId],
		ad.[StartDate],
		ad.[EndDate],
		ad.[OwnerId],
		ad.[CyclicalAssistanceFrequency],
		usr.[Name] AS OwnerName,
		usr.PhoneNumber AS OwnerPhoneNumber
FROM [Advertisement].[Advertisement] ad
JOIN Access.[User] usr on usr.Id = ad.OwnerId
