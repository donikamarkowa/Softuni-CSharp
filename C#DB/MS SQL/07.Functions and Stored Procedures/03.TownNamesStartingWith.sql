CREATE PROC usp_GetTownsStartingWith(@Letter NVARCHAR(20))
AS
SELECT 
	[Name] AS [Town]
FROM [Towns]
WHERE LOWER(SUBSTRING([Name], 1, LEN(@Letter))) = LOWER(@Letter)

GO 

EXEC usp_GetTownsStartingWith b


