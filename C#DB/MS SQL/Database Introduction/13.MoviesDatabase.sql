CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors](
      [Id] INT PRIMARY KEY,
	  [DirectorName] NVARCHAR(50) NOT NULL,
	  [Notes] NVARCHAR(50)
)

CREATE TABLE [Genres](
      [Id] INT PRIMARY KEY,
	  [GenreName] NVARCHAR(50) NOT NULL,
	  [Notes] NVARCHAR(50)
)

CREATE TABLE [Categories](
      [Id] INT PRIMARY KEY,
	  [CategoryName] NVARCHAR(50) NOT NULL,
	  [Notes] NVARCHAR(50)
)

CREATE TABLE [Movies](
      [Id] INT PRIMARY KEY,
	  [Title] NVARCHAR(50) NOT NULL,
	  [DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]),
	  [CopyrightYear] DATE,
	  [Length] NVARCHAR(50),
	  [GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]),
	  [CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
	  [Rating] SMALLINT,
	  [Notes] NVARCHAR(50)
)

INSERT INTO [Directors]([Id], [DirectorName]) 
      VALUES
	  (1, 'Koko'),
	  (2, 'Moni'),
	  (3, 'Pepo'),
	  (4, 'Kai'),
	  (5, 'Andrey')

INSERT INTO [Genres]([Id], [GenreName])
       VALUES
	   (1, 'Comedy'),
	   (2, 'Òhriller'),
	   (3, 'Drama'),
	   (4, 'Fantasy'),
	   (5, 'Action')

INSERT INTO [Categories]([Id], [CategoryName])
       VALUES
	   (1, 'First'),
	   (2, 'Second'),
	   (3, 'Third'),
	   (4, 'Forth'),
	   (5, 'Fifth')

INSERT INTO [Movies]([Id], [Title], [DirectorId])
       VALUES
	   (1, 'Avengers', 2),
	   (2, 'Purple Hearts', 1),
	   (3, 'Titanic', 4),
	   (4, 'Fast and furious', 3),
	   (5, 'After', 5)

SELECT * FROM [Categories]
SELECT * FROM [Directors]
SELECT * FROM [Genres]
SELECT * FROM [Movies]