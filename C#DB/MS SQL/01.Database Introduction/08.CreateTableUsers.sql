CREATE TABLE [Users](
       [Id] INT PRIMARY KEY IDENTITY,
	   [Username] NVARCHAR(30) NOT NULL,
	   [Password] NVARCHAR(26) NOT NULL, 
	   [ProfilePicture] VARBINARY(MAX),
	   CHECK(DATALENGTH([ProfilePicture]) <= 900000),
	   [LastLoginTime] NVARCHAR(MAX),
	   [IsDeleted] BIT
)

INSERT INTO [Users]([Username], [Password])
    VALUES
	('mariqkn', '1234'),
	('oleg', '987'),
	('peturPesho', '34d9023'),
	('goshoGog', '123'),
	('mariq04', 'mim567')



