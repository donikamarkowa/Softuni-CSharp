CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
		DECLARE @DepEmployee INT = (
												SELECT	
													[DepartmentId]
												FROM [Employees] 
												WHERE @EmployeeId = [Id]
										  )
			   DECLARE @DepReport INT = (
													SELECT 
														[c].[DepartmentId]
													FROM [Reports] AS [r]
													INNER JOIN [Categories] AS [c] ON [c].[Id] = [r].[CategoryId]
													WHERE [r].[Id] = @ReportId
										)

			IF @DepEmployee <> @DepReport 
			THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1
			ELSE 
			UPDATE [Reports]
			SET [EmployeeId] = @EmployeeId
			WHERE [Id] = @ReportId
END

GO 

EXEC usp_AssignEmployeeToReport 30, 1

EXEC usp_AssignEmployeeToReport 17, 2


