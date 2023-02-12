CREATE OR ALTER FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100)) 
RETURNS INT
AS 
BEGIN 
	DECLARE @Count INT 
	SET @Count =(
		SELECT
			COUNT(*)
		FROM Sites AS s
		JOIN SitesTourists AS st ON st.SiteId = s.Id
		WHERE s.Name = @Site
		)
	RETURN @Count
END

GO 

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Samuil’s Fortress')

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Gorge of Erma River')