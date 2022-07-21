USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='DVDCatalog')
DROP DATABASE DVDCatalog
GO

CREATE DATABASE DVDCatalog
GO

USE DVDCatalog
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='DVD')
	DROP TABLE DVD
GO

CREATE TABLE DVD (
	DVDId int identity(1,1) primary key not null,
	Title varchar(100) not null,
	ReleaseYear int not null,
	Director varchar(50) not null,
	Rating varchar(5) not null,
	Notes varchar(500),
)
GO
