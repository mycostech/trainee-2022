CREATE DATABASE todoList;
GO

USE todoList
GO

CREATE TABLE Users (
 usersID int NOT NULL,
 users varchar(255),
 pass varchar(255),
 email varchar(100),
 CONSTRAINT usersID PRIMARY KEY (usersID),
);
GO

CREATE TABLE List (
 listID int NOT NULL,
 usersID int,
 title varchar(255),
 isCompleted bit,
 dateAdded dateTime,
 dueDate dateTime,
 CONSTRAINT listID PRIMARY KEY (listID),
 CONSTRAINT FK_User FOREIGN KEY (usersID)
 REFERENCES Users(usersID),
);
GO

CREATE TABLE Task (
 ID int NOT NULL,
 listID int,
 descriptions varchar(255),
 CONSTRAINT ID PRIMARY KEY (ID),
 CONSTRAINT FK_list FOREIGN KEY (listID)
 REFERENCES List(listID),
);
GO


