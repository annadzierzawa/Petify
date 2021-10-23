CREATE VIEW [Access].[VW_UserPermissions]
AS
SELECT 
	UserId,
	RoleId,
	RoleName,
	ActionId,
	ActionName,
	[Level]
FROM 
	SVW_UserPermissions