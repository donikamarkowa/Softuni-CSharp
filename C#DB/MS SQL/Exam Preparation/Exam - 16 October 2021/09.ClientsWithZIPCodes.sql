SELECT
	CONCAT([c].[FirstName], ' ', [c].[LastName]) AS [FullName],
	[a].[Country],
	[a].[ZIP],
	CONCAT('$', 
			(	SELECT MAX([PriceForSingleCigar])		
				FROM [Cigars] AS [cig]
				INNER JOIN [ClientsCigars] AS [cc]
				ON [cig].[Id] = [cc].[CigarId]
				AND [cc].[ClientId] = [c].[Id])
			) AS [CigarPrice]
FROM [Clients] AS [c]
INNER JOIN [Addresses] AS [a] ON [a].[Id] = [c].[AddressId]
WHERE ISNUMERIC([a].[ZIP]) = 1
ORDER BY [FullName]

