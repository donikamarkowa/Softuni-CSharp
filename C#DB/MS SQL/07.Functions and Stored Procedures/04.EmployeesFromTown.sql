CREATE PROC usp_GetEmployeesFromTown (@TownName NVARCHAR(50))
AS
SELECT
	e.[FirstName],
	e.[LastName]
FROM [Towns] AS [t]
JOIN Addresses AS [a] ON [t].[TownID] = [a].[TownID]
JOIN Employees AS e ON [a].[AddressID] = [e].[AddressID]
WHERE t.Name = @TownName

GO 

EXEC usp_GetEmployeesFromTown 'Sofia'
