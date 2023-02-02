SELECT 
	[c].[CountryCode],
	COUNT([mc].[MountainID]) AS [MountainRanges]
FROM [Countries] AS [c]
LEFT JOIN [MountainsCountries] AS [mc]
ON [c].[CountryCode] = [mc].[CountryCode]
WHERE [c].[CountryName] IN ('United States', 'Russia', 'Bulgaria')
GROUP BY [c].[CountryCode]
