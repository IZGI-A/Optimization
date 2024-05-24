CREATE TABLE [dbo].[Cargoes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CourierCompany] varchar(64) NOT NULL, 
    [Deleted] DATETIME NULL,
)
