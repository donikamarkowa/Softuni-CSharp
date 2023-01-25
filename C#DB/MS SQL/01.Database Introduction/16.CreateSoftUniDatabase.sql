CREATE DATABASE [SoftUni]

USE [Softuni]

CREATE TABLE [Towns](
        [Id] INT PRIMARY KEY IDENTITY(1, 1),
		[Name] NVARCHAR(50)
)

CREATE TABLE [Addresses](
		[Id] INT PRIMARY KEY IDENTITY(1, 1),
		[AddressText] NVARCHAR(50), 
		[TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])
)

CREATE TABLE [Departments](
		[Id] INT PRIMARY KEY IDENTITY(1, 1),
		[Name] NVARCHAR(50)
)

CREATE TABLE [Employees](
		[Id] INT PRIMARY KEY,
		[FirstName] NVARCHAR(50),
		[MiddleName] NVARCHAR(50),
		[LastName] NVARCHAR(50),
		[JobTitle] NVARCHAR(50),
		[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]),
		[HireDate] DATE,
		[Salary] DECIMAL,
		[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id])
)
