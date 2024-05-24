CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Email] VARCHAR(64) NOT NULL PRIMARY KEY, 
    [Password] VARCHAR(40) NOT NULL, 
    [BranchID] INT NOT NULL FOREIGN KEY REFERENCES Branches([Id]), 
    [Deleted] DATETIME NULL,
)
