CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT
AS
BEGIN
		DECLARE @Hours INT

		IF @StartDate IS NULL OR @EndDate IS NULL
		BEGIN
		SET @Hours = 0
		END

		ELSE	
		BEGIN
		SET @HOURS = DATEDIFF(HOUR, @StartDate, @EndDate)
		END

		RETURN @Hours
END

GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports
