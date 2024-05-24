CREATE TABLE [dbo].[Shipments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CourierCompany] varchar(64) NOT NULL, 
    [Deleted] DATETIME NULL,
)
