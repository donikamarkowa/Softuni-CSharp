CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(100))
AS
SELECT
	@TouristName AS Name,
	CASE 
		WHEN COUNT(*) >= 100 THEN 'Gold badge'
		WHEN COUNT(*) >= 50 THEN 'Silver badge'
		WHEN COUNT(*) >= 25 THEN 'Bronze badge'						
	END AS Reward
FROM Tourists AS t
JOIN SitesTourists AS st ON st.TouristId = t.Id
WHERE t.Name = @TouristName

GO 

EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'

EXEC usp_AnnualRewardLottery 'Teodor Petrov'

EXEC usp_AnnualRewardLottery 'Zac Walsh'

EXEC usp_AnnualRewardLottery 'Brus Brown'