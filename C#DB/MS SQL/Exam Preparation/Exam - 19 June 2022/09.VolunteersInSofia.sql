SELECT
	v.Name,
	v.PhoneNumber,
	LTRIM(SUBSTRING(LTRIM(v.Address), 8, LEN(LTRIM(v.Address)) - 7)) AS [Address]
FROM Volunteers AS v
JOIN VolunteersDepartments AS vd ON vd.Id = v.DepartmentId
WHERE vd.DepartmentName = 'Education program assistant' AND v.Address LIKE '%Sofia%'
ORDER BY v.Name