SELECT 
	[Peaks].[PeakName],
	[Rivers].[RiverName],
	CONCAT(LOWER(LEFT([Peaks].[PeakName], LEN([Peaks].[PeakName])-1)), LOWER([Rivers].[RiverName])) AS Mix
FROM [Peaks], [Rivers]
WHERE RIGHT([Peaks].[PeakName], 1) = LEFT([Rivers].[RiverName], 1)
ORDER BY Mix
