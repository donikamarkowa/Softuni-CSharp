SELECT 
	[c].[Id],
	CONCAT([c].[FirstName], ' ', [c].[LastName]) AS [CreatorName],
	[c].[Email]
FROM [Creators] AS [c]
LEFT JOIN [CreatorsBoardgames] as [cb]
ON [cb].[CreatorId] = [c].[Id]
LEFT JOIN [Boardgames] as [b]
ON [b].[Id] = [cb].[BoardgameId]
WHERE [b].[Id] IS NULL
ORDER BY [CreatorName]



