CREATE PROCEDURE [dbo].[DeleteCategory]
    @Id INT
AS
BEGIN
    DELETE FROM dbo.Products WHERE @Id = CategoryID;

    DELETE FROM dbo.Categories WHERE @Id = CategoryID;

    SELECT @Id;
END