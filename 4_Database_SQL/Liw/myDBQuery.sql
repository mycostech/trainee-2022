CREATE DATABASE myDB;
GO

USE myDB
GO

CREATE TABLE Customers (
	CustomerID int not null,
	FirstName varchar(255),
	LastName varchar(255),
	Email varchar(100),
	PhoneNumber varchar(100),
	ClassCode int,
	CONSTRAINT PK_Customers PRIMARY KEY (CustomerID)
);
GO

ALTER TABLE Customers
ADD Age INT;

GO

INSERT INTO Customers(CustomerID,FirstName,LastName,Age,Email,PhoneNumber,ClassCode)
VALUES (1,'FirstA','LastA',20,'FirstA@gmail.com','0911234567',1)
INSERT INTO Customers(CustomerID,FirstName,LastName,Age,Email,PhoneNumber,ClassCode)
VALUES (2,'FirstB','LastB',21,'FirstB@hotmail.com','0929876543',2)
INSERT INTO Customers(CustomerID,FirstName,LastName,Age,Email,PhoneNumber,ClassCode)
VALUES (3,'FirstC','LastC',22,'FirstC@hotmail.com','0937894561',3)
INSERT INTO Customers(CustomerID,FirstName,LastName,Age,Email,PhoneNumber,ClassCode)
VALUES (4,'FirstD','LastD',22,'FirstD@gmail.com','0941253654',2)

GO

create table CustomerClass (
	ClassCode int not null,
	ClassDescription varchar(255),
	CONSTRAINT PK_CustomerClass PRIMARY KEY (ClassCode)
);
GO

INSERT INTO CustomerClass(ClassCode,ClassDescription)
VALUES (1,'Classic')
INSERT INTO CustomerClass(ClassCode,ClassDescription)
VALUES (2,'Gold')
INSERT INTO CustomerClass(ClassCode,ClassDescription)
VALUES (3,'Platinum')
GO

ALTER TABLE Customers
ADD FOREIGN KEY (ClassCode) REFERENCES CustomerClass(ClassCode);
GO

SELECT * FROM Customers
GO

SELECT * FROM CustomerClass
GO

SELECT * FROM Customers WHERE FirstName = 'FirstD'
GO

SELECT FirstName, LastName, Age, ct.ClassCode, ClassDescription
FROM Customers ct
INNER JOIN CustomerClass cc ON ct.ClassCode = cc.ClassCode;
GO

SELECT distinct Age FROM Customers
GO

SELECT *
FROM Customers
ORDER BY PhoneNumber ASC
GO

SELECT * 
FROM Customers
WHERE Email LIKE '%hotmail%'
GO

SELECT *
FROM Customers
WHERE ClassCode = (SELECT MAX(ClassCode) FROM Customers)
GO

UPDATE Customers
SET Email = 'newEmail.gmail.com'
WHERE CustomerID = 1;
GO

SELECT TOP 1 * FROM Customers ORDER BY CustomerID DESC
GO

SELECT ClassDescription
FROM Customers ct
INNER JOIN CustomerClass cc ON ct.ClassCode = cc.ClassCode
WHERE PhoneNumber LIKE '%7894561%'
GO

SELECT *
FROM Customers ct
INNER JOIN CustomerClass cc ON ct.ClassCode = cc.ClassCode
WHERE ClassDescription = 'Gold'
GO

DELETE FROM Customers WHERE FirstName = 'FirstD';
GO

CREATE VIEW CustomerDetail AS
SELECT FirstName, LastName, Age, Email, PhoneNumber, ClassDescription
FROM Customers ct
INNER JOIN CustomerClass cc ON ct.ClassCode = cc.ClassCode
GO

SELECT * FROM CustomerDetail
GO
