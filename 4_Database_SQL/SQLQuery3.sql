CREATE DATABASE myDB;
GO

USE myDB
GO

CREATE TABLE Customers (
 CustomerID int NOT NULL,
 FirstName varchar(255),
 LastName varchar(255),
 Email varchar(100),
 PhoneNumber varchar(10),
 ClassCode int
 CONSTRAINT PK_CustomerID PRIMARY KEY (CustomerID)
);
GO

ALTER TABLE Customers
ADD Age int;
GO

INSERT INTO Customers (CustomerID,FirstName,LastName,Email,PhoneNumber,ClassCode,Age)
VALUES (1,'FirstA','LastA','FirstA@gmail.com','0911234567',1,20)
INSERT INTO Customers (CustomerID,FirstName,LastName,Email,PhoneNumber,ClassCode,Age)
VALUES (2,'FirstB','LastB','FirstB@gmail.com','0929876543',2,21)
INSERT INTO Customers (CustomerID,FirstName,LastName,Email,PhoneNumber,ClassCode,Age)
VALUES (3,'FirstC','LastC','FirstC@gmail.com','0937894561',3,22)
INSERT INTO Customers (CustomerID,FirstName,LastName,Email,PhoneNumber,ClassCode,Age)
VALUES (4,'FirstD','LastD','FirstD@gmail.com','0941253654',2,22)

CREATE TABLE CustomerClass (
 ClassCode int NOT NULL,
 ClassDescription varchar(255)
 CONSTRAINT PK_CUSTOMERCLASS PRIMARY KEY (ClassCode)
);
GO

INSERT INTO CustomerClass (ClassCode,ClassDescription)
VALUES (1,'Classic')
INSERT INTO CustomerClass (ClassCode,ClassDescription)
VALUES (2,'Gold')
INSERT INTO CustomerClass (ClassCode,ClassDescription)
VALUES (3,'Platinum')

ALTER TABLE Customers
ADD CONSTRAINT FK_CUSTOMERCLASS
FOREIGN KEY (ClassCode) REFERENCES CustomerClass (ClassCode)

SELECT * FROM Customers;
SELECT * FROM CustomerClass;

SELECT * FROM Customers WHERE FirstName='FirstD'

SELECT Customers.FirstName,Customers.LastName,Customers.Age,Customers.ClassCode,ClassDescription
FROM Customers
INNER JOIN CustomerClass ON CustomerClass.ClassCode = Customers.ClassCode

SELECT Age FROM Customers
GROUP By Age

SELECT * FROM Customers
ORDER BY PhoneNumber

SELECT * FROM Customers
WHERE Email LIKE '%hotmail%'

SELECT * FROM Customers
WHERE ClassCode = (SELECT MAX(ClassCode) FROM Customers)

UPDATE Customers
SET Email = 'panut@mycostech.com'
WHERE CustomerID = 1

SELECT TOP 1 * 
FROM Customers 
ORDER BY CustomerID DESC

SELECT CustomerClass.ClassDescription
FROM Customers
INNER JOIN CustomerClass ON Customers.ClassCode = CustomerClass.ClassCode
WHERE Customers.PhoneNumber LIKE '%7894561%'

SELECT Customers.*
FROM Customers
INNER JOIN CustomerClass ON Customers.ClassCode = CustomerClass.ClassCode
WHERE CustomerClass.ClassDescription = 'Gold'

DELETE FROM Customers 
WHERE FirstName = 'FirstD'
GO


CREATE VIEW [CustomerDetail] AS
SELECT FirstName,LastName,Age,Email,PhoneNumber,CustomerClass.ClassDescription
FROM Customers
INNER JOIN CustomerClass ON Customers.ClassCode = CustomerClass.ClassCode
GO

SELECT * FROM CustomerDetail