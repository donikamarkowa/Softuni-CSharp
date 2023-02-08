SELECT TOP(5)
	o.Name,
	COUNT(a.OwnerId)
FROM Owners AS o
JOIN Animals AS a ON a.OwnerId = o.Id
GROUP BY o.Name
ORDER BY COUNT(a.OwnerId) DESC, o.Name 