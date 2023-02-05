CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
DECLARE @SalaryLevel NVARCHAR(10)
IF (@Salary < 30000)
	SET @SalaryLevel = 'Low'
ELSE IF(@Salary <= 50000)
    SET @SalaryLevel = 'Average'
ELSE
	SET @SalaryLevel = 'High'
RETURN @SalaryLevel
END

GO

SELECT 
	[Salary],
	dbo.ufn_GetSalaryLevel([Salary]) AS [Salary Level]
FROM [Employees]

