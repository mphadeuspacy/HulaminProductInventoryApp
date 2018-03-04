CREATE PROCEDURE [dbo].[CreateCategory]
   
        @Name NVARCHAR(15),   
        @Description NTEXT = NULL,
        @Picture IMAGE = NULL
AS
BEGIN 
	SET NOCOUNT ON;

    INSERT INTO [dbo].[Categories]
    SELECT  @Name, @Description, @Picture;

	SELECT SCOPE_IDENTITY();
END
																								