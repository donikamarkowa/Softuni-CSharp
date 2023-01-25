CREATE DATABASE [CarRental]

USE [CarRental]

CREATE TABLE [Categories](
      [Id] INT PRIMARY KEY, 
	  [CategoryName] NVARCHAR(50),
	  [DailyRate] INT DEFAULT(0),
	  [WeeklyRate] INT DEFAULT(0),
	  [MonthlyRate] INT DEFAULT(0),
	  [WeekendRate] INT DEFAULT(0)
)

CREATE TABLE [Cars](
       [Id] INT PRIMARY KEY, 
	   [PlateName] NVARCHAR(50), 
	   [Manufacturer] NVARCHAR(50),
	   [Model] NVARCHAR(10),
	   [CarYear] DATE,
	   [CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
	   [Doors] INT,
	   [Picture] VARBINARY(MAX),
	   [Condition] NVARCHAR(50),
	   [Available] BIT
)

CREATE TABLE [Employees](
       [Id] INT PRIMARY KEY,
	   [FirstName] NVARCHAR(50) NOT NULL, 
	   [LastName] NVARCHAR(50) NOT NULL, 
	   [Title] NVARCHAR(10),
	   [Notes] NVARCHAR(50)
)

CREATE TABLE [Customers](
        [Id] INT PRIMARY KEY,
		[DriverLicenceNumber] NVARCHAR(50) NOT NULL, 
		[FullName] NVARCHAR(50) NOT NULL,
		[Address] NVARCHAR(50), 
		[City] NVARCHAR(50),
		[ZIPCode] NVARCHAR(50),
		[Notes] NVARCHAR(50)
)

CREATE TABLE [RentalOrders](
		[Id] INT PRIMARY KEY, 
		[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
		[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]),
		[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]),
		[TankLevel] INT, 
		[KilometrageStart] INT, 
		[KilometrageEnd] INT,
		[TotalKilometrage] INT, 
		[StartDate] DATETIME2,
		[EndDate] DATETIME2,
		[TotalDays] INT, 
		[RateApplied] INT, 
		[TaxRate] INT, 
		[OrderStatus] NVARCHAR(10),
		[Notes] NVARCHAR(50)
)

INSERT INTO [Categories]([Id], [CategoryName])
      VALUES
	  (1, 'mini'),
	  (2, 'van'),
	  (3, 'suv')

INSERT INTO [Cars]([Id], [Model], [CategoryId])
     VALUES 
	 (1, 'smart', 1),
	 (2, 'sharan', 2),
	 (3, 'toyota', 3)
		
INSERT INTO [Employees]([Id], [FirstName], [LastName])
       VALUES
	   (1, 'Pesho', 'Ivanov'),
	   (2, 'Andrey', 'Petrov'),
	   (3, 'Simeon', 'Kirilov')

INSERT INTO [Customers]([Id], [DriverLicenceNumber], [FullName])
      VALUES
	  (1, '3546', 'Ivo Ivanov'),
	  (2, '9876', 'Anton Metodiev'),
	  (3, '1234', 'Petran Petkov')

INSERT INTO [RentalOrders]([Id], [EmployeeId], [CustomerId], [CarId])
      VALUES
	  (1, 2, 3, 3),
	  (2, 1, 2, 2),
	  (3, 3, 1, 1)

SELECT * FROM [Cars]
SELECT * FROM [Categories]
SELECT * FROM [Customers]
SELECT * FROM [Employees]
SELECT * FROM [RentalOrders]