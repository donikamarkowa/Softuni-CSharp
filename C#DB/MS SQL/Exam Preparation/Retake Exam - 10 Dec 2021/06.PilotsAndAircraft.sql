SELECT 
	[p].[FirstName],
	[p].[LastName],
	[a].[Manufacturer],
	[a].[Model],
	[a].[FlightHours] 
FROM [Pilots] AS [p]
JOIN [PilotsAircraft] AS [ap]
ON [ap].[PilotId] = [p].[Id]
JOIN [Aircraft] AS [a]
ON [a].[Id] = [ap].[AircraftId]
WHERE [a].[Id] IS NOT NULL AND [a].[FlightHours] <= 304
ORDER BY [a].[FlightHours] DESC, [p].[FirstName] 