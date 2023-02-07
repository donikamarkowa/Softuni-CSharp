CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(20))
AS
BEGIN 
	SELECT 
		[Id],
		[Name],
		CONCAT([Size], 'KB') AS [Size]
	FROM [Files]
	WHERE [Name] LIKE CONCAT('%', @fileExtension)
END

EXEC usp_SearchForFiles 'txt'