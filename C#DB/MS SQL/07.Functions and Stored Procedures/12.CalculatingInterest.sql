CREATE PROC usp_CalculateFutureValueForAccount(@AccountID INT, @InterestRate FLOAT)
AS
SELECT 
	[a].[Id],
	[ah]. [FirstName],
	[ah].[LastName],
	[a].[Balance] AS [Current Balance],
	dbo.ufn_CalculateFutureValue([Balance], @InterestRate, 5) AS [Balance in 5 years]
FROM [AccountHolders] AS [ah]
INNER JOIN [Accounts] AS [a]
ON [ah].[Id] = [a].[AccountHolderId]
WHERE @AccountID = [a].[Id]

GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1