SELECT 
	[c].[Id],
	CONCAT([c].[FirstName], ' ', [LastName]) AS [ClientName],
	[c].[Email]
FROM [Clients] AS [c]
LEFT JOIN [ClientsCigars] AS [cc]
ON [cc].[ClientId] = [c].[Id]
WHERE [cc].[CigarId] IS NULL
ORDER BY CONCAT([c].[FirstName], ' ', [LastName])