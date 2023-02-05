CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters NVARCHAR(20), @Word NVARCHAR(20))
RETURNS NVARCHAR(10)
BEGIN
	DECLARE @IsWordComprised INT = 0
	DECLARE @i INT = 1

	WHILE @i <= LEN(@Word)
	BEGIN
		DECLARE @WordLetter CHAR(1) = SUBSTRING(@Word, @i, 1)

		DECLARE @j INT = 1

		WHILE @j <= LEN(@SetOfLetters)
		BEGIN
			DECLARE @SetLetter CHAR(1) = SUBSTRING(@SetOfLetters, @j, 1)

			IF @WordLetter = @SetLetter
			BEGIN
				SET @IsWordComprised = 1
				BREAK
			END
			SET @j += 1
			SET @IsWordComprised = 0
		END
		
		IF @IsWordComprised = 0
		RETURN 0 
		SET @i += 1
	END
	RETURN 1
END

GO

SELECT	
	dbo.ufn_IsWordComprised 'oistmiahf', 'Sofia'
SELECT 
	dbo.ufn_IsWordComprised 'oistmiahf', 'halves'
