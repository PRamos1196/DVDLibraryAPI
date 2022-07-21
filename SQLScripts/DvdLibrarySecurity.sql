USE master
GO

CREATE LOGIN DVDApp WITH PASSWORD='Kingmjoker1'
GO

USE DVDCatalog
GO

CREATE USER DVDApp FOR LOGIN DVDApp
GO

GRANT EXECUTE ON DVDSelectAll TO DVDApp
GRANT EXECUTE ON DVDSelectById TO DVDApp
GRANT EXECUTE ON DVDInsert TO DVDApp
GRANT EXECUTE ON DVDUpdate TO DVDApp
GRANT EXECUTE ON DVDDelete TO DVDApp
GRANT EXECUTE ON RatingSelectAll TO DVDApp
GO