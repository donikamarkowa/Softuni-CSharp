CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30)) 
RETURNS INT
AS
BEGIN
		DECLARE @Count INT
		BEGIN
		SET @Count = (
		SELECT COUNT(*)
		FROM [Users] AS [u]
		INNER JOIN [Commits] AS [c]
		ON [u].[Id] = [c].[ContributorId]
		WHERE [u].[Username] = @username
		)
		END
		RETURN @Count

END

GO 

SELECT dbo.udf_AllUserCommits('UnderSinduxrein') AS [Output]