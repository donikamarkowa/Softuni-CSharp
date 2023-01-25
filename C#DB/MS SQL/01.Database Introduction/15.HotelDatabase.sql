CREATE DATABASE [Hotel]

USE [Hotel]

CREATE TABLE [Employees](
       [Id] INT PRIMARY KEY, 
	   [FirstName] NVARCHAR(50) NOT NULL, 
	   [LastName] NVARCHAR(50) NOT NULL, 
	   [Title] NVARCHAR(50),
	   [Notes] NVARCHAR(50)
)

CREATE TABLE [Customers](
        [AccountNumber] INT PRIMARY KEY,
		[FirstName] NVARCHAR(50) NOT NULL,
		[LastName] NVARCHAR(50) NOT NULL,
		[PhoneNumber] NVARCHAR(10),
		[EmergencyName] NVARCHAR(50),
		[EmergencyNumber] NVARCHAR(10),
		[Notes] NVARCHAR(50)
)

CREATE TABLE [RoomStatus](
       [RoomStatus] INT PRIMARY KEY, 
	   [Notes] NVARCHAR(50)
)

CREATE TABLE [RoomTypes](
     [RoomType] INT PRIMARY KEY,
	 [Notes] NVARCHAR(50)
)

CREATE TABLE [BedTypes](
      [BedType] INT PRIMARY KEY, 
	  [Notes] NVARCHAR(50)
)

CREATE TABLE [Rooms](
       [RoomNumber] INT PRIMARY KEY, 
	   [RoomType] INT FOREIGN KEY REFERENCES [RoomTypes]([RoomType]),
	   [BedType] INT FOREIGN KEY REFERENCES [BedTypes]([BedType]),
	   [Rate] INT, 
	   [RoomStatus] INT FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]),
	   [Notes] NVARCHAR(50)
)

CREATE TABLE [Payments](
       [Id] INT PRIMARY KEY,
	   [EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
	   [PaymentDate] DATE,
	   [AccountNumber] NVARCHAR(50),
	   [FirstDateOccupied] DATE,
	   [LastDateOccupied] DATE,
	   [TotalDays] INT, 
	   [AmountCharged] INT, 
	   [TaxRate] INT,
	   [TaxAmount] INT,
	   [PaymentTotal] INT,
	   [Notes] NVARCHAR(50)
)

CREATE TABLE [Occupancies](
        [Id] INT PRIMARY KEY, 
		[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
		[DateOccupied] DATE,
		[AccountNumber] NVARCHAR(50),
		[RoomNumber] NVARCHAR(50),
		[RateApplied] INT, 
		[PhoneCharge] INT,
		[Notes] NVARCHAR(50)
)

INSERT INTO [Employees]([Id], [FirstName], [LastName])
      VALUES
	  (1, 'Ivo', 'Petrov'),
	  (2, 'Ivan', 'Ivanov'),
	  (3, 'Teodor', 'Todorov')

INSERT INTO [Customers]([AccountNumber], [FirstName],[LastName], [PhoneNumber])
      VALUES
	  (1, 'Antoan', 'Todorov', '0896523154'),
	  (2, 'Nikolay', 'Andreev', '0896758015'),
	  (3, 'Kolio', 'Petrov', '0897458112')

INSERT INTO [RoomStatus]([RoomStatus])
      VALUES
	  (1),
	  (2),
	  (3)

INSERT INTO [RoomTypes]([RoomType])
       VALUES
	   (1),
	   (2),
	   (3)

INSERT INTO [BedTypes]([BedType])
     VALUES
	 (1),
	 (2),
	 (3)

INSERT INTO [Rooms]([RoomNumber], [RoomType], [BedType])
      VALUES
	  (1, 1, 1),
	  (2, 2, 2),
	  (3, 3, 3)

INSERT INTO [Payments]([Id], [EmployeeId])
      VALUES 
	  (1, 1),
	  (2, 2),
	  (3, 3)

INSERT INTO [Occupancies]([Id], [EmployeeId])
     VALUES
	 (1, 1),
	 (2, 2),
	 (3, 3)

SELECT * FROM [BedTypes]
SELECT * FROM [Customers]
SELECT * FROM [Employees]
SELECT * FROM [Occupancies]
SELECT * FROM [Payments]
SELECT * FROM [Rooms]
SELECT * FROM [RoomStatus]
SELECT * FROM [RoomTypes]

