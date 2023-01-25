INSERT INTO [Towns]([Name])
     VALUES
	 ('Sofia'),
	 ('Plovdiv'),
	 ('Varna'),
	 ('Burgas')

INSERT INTO [Departments]([Name])
		VALUES 
		('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Development'),
		('Quality Assurance')

INSERT INTO [Addresses]([AddressText], [TownId])
		VALUES
		('kkk', 1),
		('aaa', 2),
		('bbb', 3),
		('ooo', 4)

INSERT INTO [Employees]([FirstName], [MiddleName], [LastName], [DepartmentId], [AddressId])
    VALUES
	('Ivan', 'Ivanov', 'Ivanov', 1, 2),
	('Petar', 'Petrov', 'Petrov', 2, 3),
	('Maria', 'Petrova', 'Ivanova', 3, 1),
	('Georgi', 'Teziev', 'Ivanov', 4, 4),
	('Peter', 'Pan', 'Pan', 5, 5)


