--used in:
--VW_UserPermissions

CREATE VIEW [Access].[SVW_UserPermissions]
AS
SELECT 
	[user].Id AS UserId,
	roleAction.RoleId,
	[role].[Name] AS RoleName,
	roleAction.ActionId,
	[action].[Name] AS ActionName,
	COALESCE(userAction.[Level], roleAction.[Level]) AS [Level]
FROM 
	Access.[User] [user]
	JOIN Access.UserRole userRole ON userRole.UserId = [user].Id
	JOIN Access.RoleAction roleAction ON roleAction.RoleId = userRole.RoleId
	JOIN Access.[Action] [action] ON [action].Id = roleAction.ActionId
	JOIN Access.[Role] [role] ON [role].Id = roleAction.RoleId
	LEFT JOIN Access.UserAction userAction ON userAction.UserId = [user].Id
		AND userAction.ActionId = roleAction.ActionId