SELECT TOP(5)
	[c].[CountryName],
	[r].[RiverName]
FROM [CountriesRivers] AS [cr]
RIGHT JOIN [Countries] AS [c]
ON [cr].[CountryCode] = [c].[CountryCode]
LEFT JOIN [Rivers] AS [r]
ON [cr].[RiverId] = [r].[Id]
WHERE [c].[ContinentCode] = 'AF'
ORDER BY [c].[CountryName]
