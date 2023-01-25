CREATE TABLE [People](
       [Id] INT PRIMARY KEY IDENTITY,
	   [Name] NVARCHAR(50) NOT NULL,
	   [Picture] VARBINARY(MAX),
	   CHECK (DATALENGTH([Picture]) <= 2000000),
	   [Height] DECIMAL(3, 2),
	   [Weight] DECIMAL(5, 2),
	   [Gender] CHAR(1) NOT NULL,
	   CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	   [Birthdate] DATE NOT NULL,
	   [Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name], [Gender], [Birthdate])
     VALUES 
	 ('Gosho', 'm', '1999-03-03'),
	 ('Pesho', 'm', '1977-11-11'),
	 ('Denica', 'f', '1967-05-08'),
	 ('Kalina', 'f', '1999-12-01'),
	 ('Ivan', 'm', '2001-09-29')

SELECT * FROM [People]
