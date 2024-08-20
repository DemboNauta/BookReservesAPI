-- CREATE DATABASE BookReservationsDB

USE BookReservationsDB
GO

CREATE TABLE Authors(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255)
)

CREATE TABLE Books(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255),
    Description NVARCHAR(MAX),
    ISBN VARCHAR(13) UNIQUE,
    PublicationDate DATETIME,
    IsAvailable BIT,
    AuthorId INT,
    FOREIGN KEY(AuthorId) REFERENCES Authors(Id)
)


CREATE TABLE Users(
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(255),
    LastName NVARCHAR(255),
    Email NVARCHAR(255),
    DNI VARCHAR(9) UNIQUE NOT NULL
)

CREATE TABLE Reservations(
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    BookId INT,
    ReservationDate DATETIME,
    DueDate DATETIME,
    ReturnDate DATETIME,
    FOREIGN KEY(UserId) REFERENCES Users(Id),
    FOREIGN KEY(BookId) REFERENCES Books(Id)
)

