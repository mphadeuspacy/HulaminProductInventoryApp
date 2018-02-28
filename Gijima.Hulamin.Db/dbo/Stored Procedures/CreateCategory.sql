CREATE PROCEDURE [dbo].[Category]
   
        @Name NVARCHAR(15),   
        @Description INT = NULL,
        @Picture IMAGE = NULL
AS
    INSERT INTO [dbo].[Categories]
    SELECT  @Name, @Description, @Picture

RETURN 0
