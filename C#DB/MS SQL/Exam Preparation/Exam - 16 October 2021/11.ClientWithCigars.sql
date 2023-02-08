CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30)) 
RETURNS INT
AS
BEGIN
		DECLARE @NumOfCigars INT
		BEGIN
			SET @NumOfCigars = ( 
									SELECT COUNT(*)
									FROM [Clients] AS [c]
									INNER JOIN [ClientsCigars] AS [cc]
									ON [cc].[ClientId] = [c].[Id]
									INNER JOIN [Cigars] AS [cig]
									ON [cig].[Id] = [cc].[CigarId]
									WHERE [c].[FirstName] = @name
							   )
		END
		RETURN @NumOfCigars
END

SELECT dbo.udf_ClientWithCigars('Betty')