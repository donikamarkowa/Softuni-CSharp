SELECT 
	[r].[Description],
	[c].[Name]
FROM [Reports] AS [r]
INNER JOIN [Categories] AS [c]
ON [r].CategoryId = [c].[Id]
ORDER BY [r].[Description], [c].[Name]