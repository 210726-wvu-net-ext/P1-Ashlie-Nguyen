select * from Customers;
select * from Locations;
select * from Orders;
select * from Products;
select * from ProductOrders;


CREATE TABLE [dbo].[Customer] (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    FirstName VARCHAR (50) NOT NULL,
    LastName VARCHAR (50) NOT NULL,
    RegistrationDate DATE,
    Phone VARCHAR(20)
);
CREATE TABLE [dbo].[Location] (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    Store VARCHAR (50) NOT NULL,
    [StreetAddress] VARCHAR (50) NOT NULL,
	ZipCode VARCHAR (10) NOT NULL,
	[State] VARCHAR (20) NOT NULL,
    OpeningDate DATE,
    [Hours] VARCHAR(20),
    Phone VARCHAR(20)
);
CREATE TABLE [dbo].[Order] (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    OrderDate DATE,
    TotalPrice DECIMAL(5,2),
	Customer INT NOT NULL,
	[Location] INT NOT NULL,
    FOREIGN KEY (Customer) REFERENCES [dbo].[Customer] (Id),
    FOREIGN KEY ([Location]) REFERENCES [dbo].[Location] (Id)
);
CREATE TABLE [dbo].[Product] (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    [Name] VARCHAR (50) NOT NULL,
    Category VARCHAR (50) NOT NULL,
    ReleaseDate DATE,
    Price DECIMAL(5,2)
);
CREATE TABLE [dbo].[ProductOrder] (
    Id INT PRIMARY KEY IDENTITY (1, 1),
	Number INT NOT NULL,
    Product INT NOT NULL,
    [Order] INT NOT NULL,
    FOREIGN KEY (Product) REFERENCES [dbo].[Product] (Id),
    FOREIGN KEY ([Order]) REFERENCES [dbo].[Order] (Id)
);USE P1
SELECT  'DROP TABLE [' + name + '];'
FROM    sys.tables;

DROP TABLE [__EFMigrationsHistory];
DROP TABLE [ProductOrder];
DROP TABLE [Order];
DROP TABLE [Customer];
DROP TABLE [Location];
DROP TABLE [Product];