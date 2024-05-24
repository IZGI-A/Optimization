CREATE TABLE [dbo].[Branches]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(64) NOT NULL, 
    [Address] VARCHAR(256) NOT NULL, 
    [PhoneNumber] VARCHAR(11) NOT NULL, 
    [Deleted] DATETIME NULL,
)
