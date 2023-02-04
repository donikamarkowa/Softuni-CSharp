SELECT 
	[DepartmentID],
	SUM([Salary]) AS [TotalSum]
FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]