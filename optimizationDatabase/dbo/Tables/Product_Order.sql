CREATE TABLE [dbo].[Product_Order]
(
	[NumberOfProducts] INT NOT NULL,
	[ProductID] INT NOT NULL FOREIGN KEY REFERENCES Products([Id]),
	[CustomerID] INT NOT NULL FOREIGN KEY REFERENCES Customers([Id]),
	[OrderID] INT NOT NULL FOREIGN KEY REFERENCES Orders([Id]),
)
