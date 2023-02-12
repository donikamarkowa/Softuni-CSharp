SELECT 
	[p].[FullName],
	COUNT([fd].[AircraftId]) AS [CountOfAircraft],
	SUM([fd].[TicketPrice]) AS [TotalPayed]
FROM [Passengers] AS [p]
JOIN [FlightDestinations] AS [fd]
ON [fd].[PassengerId] = [p].[Id]
GROUP BY [p].[FullName]
HAVING [p].[FullName] LIKE '_a%' AND COUNT([fd].[AircraftId]) > 1
ORDER BY [p].[FullName]