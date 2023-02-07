SELECT 
	[u].[Username],
	[c].[Name] AS [CategoryName]
FROM [Users] AS [u]
LEFT JOIN [Reports] AS [r]
ON [r].[UserId] = [u].[Id]
LEFT JOIN [Categories] AS [c]
ON [c].[Id] = [r].[CategoryId]
WHERE FORMAT(CAST([u].[Birthdate] AS DATE), 'MM-dd') = FORMAT(CAST([r].[OpenDate] AS DATE), 'MM-dd')
ORDER BY [u].[Username], [c].[Name]