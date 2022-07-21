USE DVDCatalog
GO

-- Stored Procedures

-- Create
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'usp_DVDCreate')
      DROP PROCEDURE usp_DVDCreate
GO

CREATE PROCEDURE usp_DVDCreate (
	@DVDId INT OUTPUT,
	@Title NVARCHAR(100),
	@ReleaseYear INT,
	@Director NVARCHAR(50),
	@Rating NVARCHAR(5),
	@Notes NVARCHAR(500)
)
AS
BEGIN
	INSERT INTO DVD(
		[Title],
		[ReleaseYear],
		[Director],
		[Rating],
		[Notes]
	)
	VALUES(
		@Title,
		@ReleaseYear,
		@Director,
		@Rating,
		@Notes
	)
	SET @DVDId = SCOPE_IDENTITY()
END


-- Delete
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'usp_DVDDelete')
      DROP PROCEDURE usp_DVDDelete
GO

CREATE PROCEDURE usp_DVDDelete(@DVDId INT OUTPUT)
AS
BEGIN
	DELETE FROM DVD WHERE @DVDId = DVDId
END
GO


-- Select All
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'usp_DVDSelectAll')
      DROP PROCEDURE usp_DVDSelectAll
GO

CREATE PROCEDURE usp_DVDSelectAll
AS
BEGIN
	SELECT DVDId,Title,ReleaseYear,Director,Rating,Notes
	FROM DVD
END
GO

-- GET BY DIRECTOR
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'usp_DVDGetByDirector')
      DROP PROCEDURE usp_DVDGetByDirector
GO

CREATE PROCEDURE usp_DVDGetByDirector(@Director nvarchar(50))
AS
BEGIN
	SELECT DVDId,Title,ReleaseYear,Director,Rating,Notes
	FROM DVD d
	WHERE d.Director LIKE @Director + '%'
END
GO

-- Select By ID
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'usp_DVDSelectById')
      DROP PROCEDURE usp_DVDSelectById
GO

CREATE PROCEDURE usp_DVDSelectById(@DVDId int)
AS
BEGIN
	SELECT DVDId,Title,ReleaseYear,Director,Rating,Notes
	FROM DVD
	WHERE DVDId = @DVDId
END
GO

-- Select By Rating 
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'usp_DVDGetByRating')
      DROP PROCEDURE usp_DVDGetByRating
GO

CREATE PROCEDURE usp_DVDGetByRating(@Rating nvarchar(5))
AS
BEGIN
	SELECT DVDId,Title,ReleaseYear,Director,Rating,Notes
	FROM DVD
	WHERE Rating LIKE @Rating + '%'
END
GO

-- Select By Rating 
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'usp_DVDGetByReleaseYear')
      DROP PROCEDURE usp_DVDGetByReleaseYear
GO

CREATE PROCEDURE usp_DVDGetByReleaseYear(@ReleaseYear int)
AS
BEGIN
	SELECT DVDId,Title,ReleaseYear,Director,Rating,Notes
	FROM DVD
	WHERE ReleaseYear = @ReleaseYear
END
GO


-- Select By Rating 
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'usp_DVDGetByTitle')
      DROP PROCEDURE usp_DVDGetByTitle
GO

CREATE PROCEDURE usp_DVDGetByTitle(@Title nvarchar(100))
AS
BEGIN
	SELECT DVDId,Title,ReleaseYear,Director,Rating,Notes
	FROM DVD
	WHERE Title = @Title
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'usp_DVDUpdate')
      DROP PROCEDURE usp_DVDUpdate
GO

CREATE PROCEDURE usp_DVDUpdate(
	@DVDId INT,
	@Title NVARCHAR(100),
	@ReleaseYear INT,
	@Director NVARCHAR(50),
	@Rating NVARCHAR(5),
	@Notes NVARCHAR(500)
)
AS
BEGIN
	UPDATE DVD
	SET 
		Title = @Title,
		ReleaseYear = @ReleaseYear,
		Director = @Director,
		Rating = @Rating,
		Notes = @Notes
	WHERE @DVDId = DVDId;
END