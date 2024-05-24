CREATE TABLE [dbo].[Branch_Product]
(
	[BranchID] INT NOT NULL FOREIGN KEY REFERENCES Branches([Id]), 
    [ProductID] INT NOT NULL FOREIGN KEY REFERENCES Products([Id]),
)