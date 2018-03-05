CREATE PROCEDURE [dbo].[DeleteProduct]
    @Id int
AS
BEGIN
    DELETE FROM dbo.[Products] WHERE @Id = ProductID;

    SELECT @Id;
END