SELECT
	CASE 
		WHEN [e].[Id] IS NULL THEN 'None'
		ELSE
	   CONCAT([e].[FirstName], ' ', [e].[LastName]) 
	END AS [Employee],
	ISNULL([d].[Name], 'None') AS [Department],
	[c].[Name] AS [Category],
	[r].[Description],
	FORMAT(CAST([r].[OpenDate] AS DATE), 'dd.MM.yyyy') AS [OpenDate],
	[s].[Label] AS [Status],
	[u].[Name] AS [User]
FROM [Reports] AS [r]
LEFT JOIN [Employees] AS [e] 
ON [e].[Id] = [r].[EmployeeId]
LEFT JOIN [Users] AS [u] 
ON [u].[Id] = [r].[UserId]
LEFT JOIN Departments AS [d]
ON [d].[Id] = [e].[DepartmentId]
LEFT JOIN [Categories] AS [c]
ON [c].[Id] = [r].[CategoryId]
LEFT JOIN [Status] AS [s]
ON [s].[Id] = [r].[StatusId]
ORDER BY [e].[FirstName] DESC, [e].[LastName] DESC, [d].[Name], [c].[Name], [r].[Description], [r].[OpenDate], [s].[Label], [u].[Name]