
ALTER PROCEDURE [dbo].[TestProcedure] 
@Name nvarchar(50) = null,
@Count int out
AS
BEGIN

	declare @x int = 0;

	select @x = count(*) from Students;

	set @Count = @x;

	select * from Students where [Name] = @Name;
	
END


GO
