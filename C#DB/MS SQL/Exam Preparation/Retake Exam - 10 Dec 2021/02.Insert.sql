INSERT INTO [Passengers]([FullName], [Email])
SELECT
	CONCAT([p].[FirstName], ' ',[p].[LastName]),
	CONCAT([p].[FirstName], [p].[LastName], '@gmail.com')
FROM [Pilots] AS [p]
WHERE [p].[Id] BETWEEN 5 AND 15

