SELECT CONCAT([FirstName],' ', [MiddleName],' ', [LastName])
       AS [FullName]
	   FROM [Employees]
	   Where [Salary] IN (25000, 14000, 12500, 23600)