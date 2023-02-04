SELECT * 
INTO [EmployeesNewTable]
FROM [Employees]
WHERE [Salary] > 30000

DELETE 
FROM [EmployeesNewTable]
WHERE [ManagerID] = 42

UPDATE 
[EmployeesNewTable]
SET [Salary] += 5000
WHERE [DepartmentID] = 1

SELECT 
	[DepartmentID],
	AVG([Salary]) AS [AverageSalary]
FROM [EmployeesNewTable]
GROUP BY [DepartmentID]