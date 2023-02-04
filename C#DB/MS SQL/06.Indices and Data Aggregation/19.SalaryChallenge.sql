SELECT TOP(10)
	[FirstName],
	[LastName],
	[DepartmentID]
FROM [Employees] AS [e]
WHERE [Salary] > (
					SELECT 
						AVG([Salary]) AS [AverageSalary]
					FROM [Employees] AS [e2]
					WHERE [e].[DepartmentID] = [e2].[DepartmentID]
					GROUP BY [DepartmentID]
				 )
ORDER BY [DepartmentID]