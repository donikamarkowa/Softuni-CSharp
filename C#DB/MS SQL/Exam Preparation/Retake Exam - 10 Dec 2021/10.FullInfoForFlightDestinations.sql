SELECT 
	[a].[AirportName],
	[fd].[Start] AS [DayTime],
	[fd].[TicketPrice],
	[p].[FullName],
	[ac].[Manufacturer],
	[ac].[Model]
FROM [FlightDestinations] AS [fd]
JOIN [Airports] AS [a]
ON [a].[Id] = [fd].[AirportId]
JOIN [Passengers] AS [p]
ON [fd].[PassengerId] = [p].[Id]
JOIN [Aircraft] AS [ac]
ON [ac].[Id] = [fd].[AircraftId]
WHERE DATEPART(HOUR, [fd].[Start]) BETWEEN 6.00 AND 20.00
AND [fd].[TicketPrice] > 2500
ORDER BY [ac].[Model]