CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(100)) 
RETURNS INT
AS
BEGIN
		DECLARE @Count INT 

		SET @COUNT = (
			SELECT COUNT(*)
			FROM [Passengers] AS [p]
			JOIN [FlightDestinations] AS [fd]
			ON [fd].[PassengerId] = [p].[Id]
			WHERE [Email] = @email
		)

		RETURN @Count
END

GO 

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')

SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')

SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')