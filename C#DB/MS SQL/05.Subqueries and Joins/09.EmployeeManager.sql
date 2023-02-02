SELECT 
	[e2].[EmployeeID],
	[e2].[FirstName],
	[e2].[ManagerID],
	[e].[FirstName] AS [ManagerName]
FROM [Employees] AS [e]
LEFT JOIN [Employees] AS [e2]
ON [e].[EmployeeID] = [e2].[ManagerID]
WHERE [e2].[ManagerID] IN (3, 7)
ORDER BY [e2].[EmployeeID]