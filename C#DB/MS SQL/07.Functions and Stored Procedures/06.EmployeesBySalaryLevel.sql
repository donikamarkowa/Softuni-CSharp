CREATE PROC usp_EmployeesBySalaryLevel(@LevelOfSalary NVARCHAR(10))
AS
SELECT 
	[FirstName] AS [First Name],
	[LastName] AS [Last Name]
FROM [Employees]
WHERE dbo.ufn_GetSalaryLevel([Salary]) = @LevelOfSalary

GO

EXEC usp_EmployeesBySalaryLevel 'High'