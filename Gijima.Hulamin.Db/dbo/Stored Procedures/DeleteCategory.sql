CREATE PROCEDURE [dbo].[DeleteCategory]
    @Id int
AS
BEGIN
    DELETE FROM dbo.Categories WHERE @Id = CategoryID;

    SELECT @Id;
END