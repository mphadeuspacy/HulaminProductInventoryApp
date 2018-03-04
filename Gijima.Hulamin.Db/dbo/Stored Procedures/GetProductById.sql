CREATE PROCEDURE [dbo].[GetProductById]
	@Id INT = 0
AS
BEGIN
	SELECT * FROM [dbo].[Products] WHERE @Id = ProductID;
END
