CREATE VIEW [Pet].[VW_PetItems]
AS
SELECT
	  pet.[Id],
	  pet.[Name],
	  pet.[SpeciesId],
	  pet.[DateOfBirth],
	  pet.[Description],
	  pet.[UserId],
	  pet.[CreatedBy],
	  pet.[CreatedOn],
	  pet.[UpdatedBy],
	  pet.[UpdatedOn],
	  pet.[ImageFileStorageId],
	  speciesType.[Name] AS SpeciesName
FROM
	  Pet.Pet pet
	  JOIN Lookup.SpeciesType speciesType ON pet.SpeciesId = speciesType.Id
