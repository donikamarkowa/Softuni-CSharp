SELECT 
	[c].[LastName], 
	CEILING(AVG([b].[Rating])) AS [AverageRating],
	[p].[Name] AS [PublisherName]
FROM [Creators] AS [c]
JOIN [CreatorsBoardgames] AS [cb]
ON [cb].[CreatorId] = [c].[Id]
JOIN [Boardgames] AS [b]
ON [cb].[BoardgameId] = [b].[Id]
JOIN [Publishers] AS [p]
ON [b].[PublisherId] = [p].[Id]
WHERE [p].[Name] = 'Stonemaier Games'
GROUP BY [c].[LastName], [p].[Name]
ORDER BY AVG([b].[Rating]) DESC


