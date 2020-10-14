CREATE TABLE [dbo].[Products]
(
	[ProductId] NUMERIC(18,0) IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [ProductIdentity] UNIQUEIDENTIFIER NULL, 
    [ProductName] VARCHAR(50) NULL, 
    [UnitPrice] FLOAT NULL
)
