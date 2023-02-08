SELECT 
	[c].[LastName],
	AVG([s].[Length]) AS [CiagrLength],
	CEILING(AVG([s].[RingRange])) AS [CiagrRingRange]
FROM [Clients] AS [c]
INNER JOIN [ClientsCigars] AS [cc]
ON [c].Id = [cc].[ClientId]
INNER JOIN [Cigars] AS [cig]
ON [cig].[Id] = [cc].[CigarId]
INNER JOIN [Sizes] AS [s]
ON [s].[Id] = [cig].[SizeId]
GROUP BY [c].[LastName]
ORDER BY AVG([s].[Length]) DESC

