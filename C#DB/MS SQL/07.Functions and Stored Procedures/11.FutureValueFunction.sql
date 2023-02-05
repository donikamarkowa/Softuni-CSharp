CREATE FUNCTION ufn_CalculateFutureValue (@Sum DECIMAL(18,4), @Yrate FLOAT, @years INT)
RETURNS DECIMAL(18,4)
BEGIN
    DECLARE @Result DECIMAL(18,4) = @Sum * POWER((1+ @Yrate),@years)
    RETURN @Result
END

GO 

SELECT dbo.ufn_CalculateFutureValue (1000, 0.1, 5)