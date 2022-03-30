CREATE DATABASE myDB;
GO

USE myDB
GO

CREATE TABLE Customers (
 CustomerID int NOT NULL,
 FirstName varchar(255),
 LastName varchar(255),
 Email varchar(100),
 PhoneNumber varchar(255),
 ClassCode int,
 CONSTRAINT CustomerID PRIMARY KEY (CustomerID),
);
GO

ALTER TABLE Customers
  ADD Age int;
 GO

INSERT INTO Customers (CustomerID,FirstName,LastName,Age,Email,PhoneNumber,ClassCode)
VALUES (1,'FirstA','LastA','20','FirstA@gmail.com','0911234567',1)
INSERT INTO Customers (CustomerID,FirstName,LastName,Age,Email,PhoneNumber,ClassCode)
VALUES (2,'FirstB','LastB','21','FirstB@hotmail.com','0929876543',2)
INSERT INTO Customers (CustomerID,FirstName,LastName,Age,Email,PhoneNumber,ClassCode)
VALUES (3,'FirstC','LastC','22','FirstC@hotmail.com','0937894561',3)
INSERT INTO Customers (CustomerID,FirstName,LastName,Age,Email,PhoneNumber,ClassCode)
VALUES (4,'FirstD','LastD','22','FirstB@gmail.com','0941253654',2)
GO

CREATE TABLE CustomerClass (
 ClassCode int NOT NULL,
 ClassDescription  varchar(255),
 CONSTRAINT ClassCode PRIMARY KEY (ClassCode),
);
GO

INSERT INTO CustomerClass (ClassCode, ClassDescription)
VALUES (1,'Classic')
INSERT INTO CustomerClass (ClassCode, ClassDescription)
VALUES (2,'Gold')
INSERT INTO CustomerClass (ClassCode, ClassDescription)
VALUES (3,'Platinum')
GO

ALTER TABLE Customers
ADD CONSTRAINT FK_ClassCode
FOREIGN KEY (ClassCode) REFERENCES CustomerClass(ClassCode);
GO

SELECT * FROM Customers, CustomerClass
GO

SELECT * FROM Customers
WHERE FirstName = 'FirstD'
GO

SELECT FirstName, LastName, Age, CustomerClass.ClassCode, ClassDescription FROM Customers, CustomerClass
GO

SELECT DISTINCT Age FROM Customers
Go

SELECT * FROM Customers
ORDER BY PhoneNumber
Go

SELECT * FROM Customers
WHERE Email LIKE '%hotmail%'
GO

SELECT MAX(ClassCode) AS 'highest value of the ClassCode'
FROM CustomerClass
GO

UPDATE Customers
SET Email = 'new.gmail.com'
WHERE CustomerID=1
GO

SELECT TOP 1 * FROM Customers ORDER BY CustomerID DESC
GO

SELECT * FROM CustomersWHERE PhoneNumber LIKE '%7894561%'
GO

SELECT * FROM CustomersWHERE PhoneNumber LIKE '%7894561%'
GO

SELECT *
FROM CustomersINNER JOIN CustomerClass ON Customers.ClassCode = CustomerClass.ClassCode
WHERE ClassDescription = 'Gold';
GO

DELETE FROM Customers WHERE FirstName='FirstD'
GO

CREATE VIEW CustomerDetail
ASSELECT FirstName, LastName, Age, Email, PhoneNumber, ClassDescription
FROM Customers INNER JOIN CustomerClass ON Customers.ClassCode = CustomerClass.ClassCode
GO

SELECT * FROM CustomerDetail
GO