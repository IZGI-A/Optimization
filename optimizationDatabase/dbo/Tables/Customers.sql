CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] varchar(64) NOT NULL,
	[Surname] varchar(64) NOT NULL,
	[Address] varchar(256) NOT NULL,
	[PhoneNumber] varchar(11) NOT NULL, 
    [Deleted] DATETIME NULL,
)
