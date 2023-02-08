SELECT
	a.Name,
	DATEPART(YEAR, a.BirthDate) AS BirthDate,
	at.AnimalType
FROM Animals AS a
JOIN AnimalTypes AS at ON at.Id = a.AnimalTypeId
WHERE a.OwnerId IS NULL AND (DATEDIFF(YEAR, BirthDate, '2022-01-01') < 5 AND at.AnimalType <> 'Birds')
ORDER BY a.Name