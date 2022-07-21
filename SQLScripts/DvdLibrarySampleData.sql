USE DVDCatalog
GO
SET IDENTITY_INSERT DVD ON;
INSERT INTO DVD(
	[DVDId],
	[Title],
	[ReleaseYear],
	[Director],
	[Rating],
	[Notes]
)
VALUES
(1, 'Bee Movie', 2012, 'No Clue', 'PG', 'Beetastic'),
(2, 'Dr.Strange', 2018, 'Scott Derrickson', 'PG-13', 'He is very strange'),
(3, 'Star Wars', 1977, 'George Lucas', 'PG-13', 'He is very strange'),
(4, 'Dune', 2021, 'Denis Villeneuve', 'PG-13', 'Spectacular'),
(5, 'Small Soldiers', 1998, 'Joe Dante', 'PG-13', 'Silly')


SET IDENTITY_INSERT DVD OFF;

SELECT * FROM DVD;

