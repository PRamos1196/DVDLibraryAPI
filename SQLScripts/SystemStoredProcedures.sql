
exec [dbo].[usp_DVDSelectAll]
exec [dbo].[usp_DVDGetByTitle] 'Despicable Me'

exec [dbo].[usp_DVDDelete] 23


select * from dvd