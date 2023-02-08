CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
		SELECT 
			[c].[CigarName],
			CONCAT('$', [c].[PriceForSingleCigar]) AS [Price],
			[t].[TasteType],
			[b].[BrandName],
			CONCAT([s].[Length], ' ','cm') AS [CigarLength],
			CONCAT([s].[RingRange], ' ', 'cm') AS [CigarRingRange]
		FROM [Cigars] AS [c]
		INNER JOIN [Tastes] AS [t]
		ON [t].[Id] = [c].[TastId]
		INNER JOIN [Brands] AS [b]
		ON [c].[BrandId] = [b].[Id]
		INNER JOIN [Sizes] AS [s]
		ON [c].[SizeId] = [s].[Id]
		WHERE [t].[TasteType] = @taste
		ORDER BY [CigarLength], [CigarRingRange] DESC
END 

EXEC usp_SearchByTaste 'Woody'