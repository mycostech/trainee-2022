CREATE DATABASE myDB;
GO

USE myDB
GO

CREATE TABLE Customers (
 CustomerID  int NOT NULL,
 FirstName varchar(255),
 LastName varchar(255),
 Email varchar(100),
 PhoneNumber varchar(10),
 ClassCode int,
 CONSTRAINT PK_Customers PRIMARY KEY (CustomerID)
);
GO

ALTER TABLE CustomersADD Age int;
GO

INSERT INTO Customers (CustomerID,FirstName,LastName,Age,Email,PhoneNumber,ClassCode)
VALUES (1,'FirstA','LastA',20,'FirstA@gmail.com','0911234567',1)
INSERT INTO Customers (CustomerID,FirstName,LastName,Age,Email,PhoneNumber,ClassCode)
VALUES (2,'FirstB','LastB',21,'FirstB@hotmail.com','0929876543',2)
INSERT INTO Customers (CustomerID,FirstName,LastName,Age,Email,PhoneNumber,ClassCode)
VALUES (3,'FirstC','LastC',22,'FirstC@hotmail.com','0937894561',3)
INSERT INTO Customers (CustomerID,FirstName,LastName,Age,Email,PhoneNumber,ClassCode)
VALUES (4,'FirstD','LastD',22,'FirstD@gmail.com','0941253654',2)
GO

CREATE TABLE CustomerClass (
 ClassCode int NOT NULL,
 ClassDescription varchar(255),
 CONSTRAINT PK_CustomerClass PRIMARY KEY (ClassCode)
);
GO

INSERT INTO CustomerClass (ClassCode, ClassDescription)
VALUES (1,'Classic')
INSERT INTO CustomerClass (ClassCode, ClassDescription)
VALUES (2,'Gold')
INSERT INTO CustomerClass (ClassCode, ClassDescription)
VALUES (3,'Platunum')
GO

ALTER TABLE Customers ADD CONSTRAINT FK_CustomerClass FOREIGN KEY (ClassCode) REFERENCES CustomerClass(ClassCode);
GO

SELECT * FROM Customers

SELECT * FROM CustomerClass

SELECT * FROM Customers WHERE FirstName = 'FirstD'

SELECT Customers.FirstName, Customers.LastName, Customers.Age, Customers.ClassCode, CustomerClass.ClassDescription FROM Customers
INNER JOIN CustomerClass ON Customers.ClassCode = CustomerClass.ClassCode

SELECT Age FROM Customers GROUP BY Age;

SELECT * FROM Customers ORDER BY PhoneNumber;

SELECT * FROM Customers WHERE Email LIKE '%hotmail%'

SELECT * FROM Customers WHERE ClassCode = (SELECT MAX(ClassCode) FROM Customers)

UPDATE Customers Set Email = 'thirasak@mycostech.com' WHERE CustomerID  = 1
GO

SELECT TOP 1  * FROM Customers ORDER BY CustomerID DESC

SELECT CustomerClass.ClassDescription FROM Customers 
INNER JOIN CustomerClass ON Customers.ClassCode = CustomerClass.ClassCode
WHERE PhoneNumber LIKE '%7894561%'

SELECT * FROM Customers 
INNER JOIN CustomerClass ON Customers.ClassCode = CustomerClass.ClassCode
WHERE CustomerClass.ClassDescription = 'Gold'

DELETE FROM Customers WHERE FirstName='FirstD'
GO

CREATE VIEW [CustomerDetail] AS
SELECT Customers.FirstName, Customers.LastName, Customers.Age, Customers.Email, Customers.PhoneNumber, CustomerClass.ClassDescription
FROM Customers
INNER JOIN CustomerClass ON Customers.ClassCode = CustomerClass.ClassCode
GO

SELECT * FROM [CustomerDetail]