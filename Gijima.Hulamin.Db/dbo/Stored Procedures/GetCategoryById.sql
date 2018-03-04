CREATE PROCEDURE [dbo].[GetCategoryById]
	@Id INT = 0
AS
BEGIN
	SELECT * FROM [dbo].[Categories] WHERE @Id = CategoryID;
END
