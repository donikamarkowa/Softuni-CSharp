SELECT 
	[DepartmentID],
	MIN([Salary]) AS [MinimumSalary]
FROM [Employees]
WHERE [DepartmentID] IN (2, 5, 7)
GROUP BY [DepartmentID]