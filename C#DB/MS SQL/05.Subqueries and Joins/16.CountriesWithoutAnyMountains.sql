SELECT 
	COUNT([CountriesWithoutMountains].[CountryCode])
FROM 
	(
	SELECT 
		[c].[CountryCode]
	FROM [Countries] AS [c]
	LEFT JOIN [MountainsCountries] AS [mc] 
	ON [mc].[CountryCode] = [c].[CountryCode]
	WHERE [mc].[MountainId] IS NULL
	) AS [CountriesWithoutMountains]