CREATE FUNCTION udf_CreatorWithBoardgames (@name VARCHAR(30)) 
RETURNS INT
AS
BEGIN
		DECLARE @count INT
		SET @count = 
		(
			SELECT 
				COUNT(*)
			FROM [Creators] AS [c]
			JOIN [CreatorsBoardgames] AS [cb] 
			ON [cb].[CreatorId] = [c].[Id]
			JOIN [Boardgames] AS [b]
			ON [b].[Id] = [cb].[BoardgameId]
			WHERE [c].[FirstName] = @name
		)

		RETURN @count
END 
