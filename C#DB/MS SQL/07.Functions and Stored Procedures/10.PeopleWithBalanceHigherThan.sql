CREATE PROC usp_GetHoldersWithBalanceHigherThan(@Number MONEY)
AS
	SELECT 
		[ah].[FirstName] AS [First Name],
		[ah].[LastName] AS [Last Name]
	FROM [AccountHolders] AS [ah]
	LEFT JOIN [Accounts] AS [a]
	ON [ah].[Id] = [a].[AccountHolderId]
	GROUP BY [FirstName], [LastName]
	HAVING SUM([a].[Balance]) > @Number
	ORDER BY [ah].[FirstName], [ah].[LastName]

GO

EXEC usp_GetHoldersWithBalanceHigherThan 1000