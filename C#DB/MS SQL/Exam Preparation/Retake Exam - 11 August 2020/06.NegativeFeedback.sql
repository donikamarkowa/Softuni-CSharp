SELECT
	ProductId,
	Rate,
	Description,
	CustomerId,
	Age,
	Gender
FROM Feedbacks AS f
JOIN Customers AS c ON c.Id = f.CustomerId
WHERE Rate < 5
ORDER BY ProductId DESC, Rate 