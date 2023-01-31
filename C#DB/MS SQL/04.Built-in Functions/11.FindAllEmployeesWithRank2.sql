SELECT * FROM(
SELECT 
	[EmployeeID],
	[FirstName],
	[LastName],
	[Salary],
	DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) 
	AS RANK
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000
)
AS [RankTwo]
WHERE [Rank] = 2
ORDER BY [Salary] DESC
