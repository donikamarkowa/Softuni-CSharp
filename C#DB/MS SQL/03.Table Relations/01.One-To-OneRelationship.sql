CREATE TABLE [Manufacturers]
(
	 [Id] INT PRIMARY KEY IDENTITY,
	 [Name] NVARCHAR(50) NOT NULL,
	 [EstablishedOn] DATE NOT NULL
)

CREATE TABLE [Models]
(
		[Id] INT PRIMARY KEY IDENTITY(101, 1),
		[Name] NVARCHAR(50) NOT NULL,
		[ManifacturerId] INT FOREIGN KEY REFERENCES [Manufacturers]([Id]) NOT NULL
)

INSERT INTO [Manufacturers]([Name], [EstablishedOn])
	VALUES
	('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966')

--SELECT * FROM [Manufacturers]

INSERT INTO [Models]([Name], [Id])
		VALUES
		('X1', 1),
		('i6', 1),
		('Model S', 2),
		('Model X', 2),
		('Model 3', 2),
		('Nova', 3)

--SELECT * FROM [Models]
		