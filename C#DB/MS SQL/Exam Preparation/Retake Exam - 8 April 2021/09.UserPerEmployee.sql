SELECT 
	CONCAT([e].[FirstName], ' ', [e].[LastName]) AS [FullName],
	COUNT([u].[Id])
FROM [Employees] AS [e]
LEFT JOIN [Reports] AS [r]
ON [r].[EmployeeId] = [e].[Id]
LEFT JOIN [Users] AS [u]
ON [u].[Id] = [r].[UserId]
GROUP BY CONCAT([e].[FirstName], ' ', [e].[LastName])
ORDER BY COUNT([u].[Id]) DESC, CONCAT([e].[FirstName], ' ', [e].[LastName])