
CREATE FUNCTION TestFunction 
(
	@X int,
	@Y int
)
RETURNS int
AS
BEGIN

	
	RETURN @X + @Y;

END
GO

