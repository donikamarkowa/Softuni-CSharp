SELECT
	FirstName,
	Age,
	PhoneNumber
FROM Customers
WHERE Age >= 21 AND (LOWER(FirstName) LIKE '%an%' OR PhoneNumber LIKE '%38') AND CountryId <> 31
ORDER BY FirstName, Age DESC