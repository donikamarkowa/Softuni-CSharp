CREATE PROC usp_DeleteEmployeesFromDepartment (@DepartmentId INT)
AS
BEGIN
	DELETE FROM [EmployeesProjects]
	WHERE [EmployeeID] IN (
								SELECT 
									[EmployeeID]
								FROM [Employees]
								WHERE [DepartmentID] = @DepartmentId
						  )

	UPDATE [Employees]
	SET [ManagerID] = NULL
	WHERE [ManagerID] IN (
								SELECT 
									[EmployeeID]
								FROM [Employees]
								WHERE [DepartmentID] = @DepartmentId
					     )

	ALTER TABLE [Departments]
	ALTER COLUMN [ManagerID] INT

	UPDATE [Departments]
		SET [ManagerID] = NULL
	WHERE [ManagerID] IN (
								SELECT 
									[EmployeeID]
								FROM [Employees]
								WHERE [DepartmentID] = @DepartmentId
						 )

	DELETE FROM [Employees]
	WHERE [EmployeeID] IN 
							(
								SELECT 
									[EmployeeID]
								FROM [Employees]
								WHERE [DepartmentID] = @DepartmentId
							)
	
	DELETE FROM [Departments]
	WHERE [DepartmentID] = @DepartmentId

	SELECT COUNT([EmployeeID])
	FROM [Employees]
	WHERE [DepartmentID] = @DepartmentId
END 

GO 

EXEC dbo.usp_DeleteEmployeesFromDepartment 1