CREATE TABLE [dbo].[Equipment]
(
	[Name] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Agility] INT NULL, 
    [Price] INT NULL, 
    [Intelligence] INT NULL, 
    [Strength] INT NULL, 
    [ImageURL] NVARCHAR(1000) NULL, 
    [Category] NVARCHAR(50) NULL
)
