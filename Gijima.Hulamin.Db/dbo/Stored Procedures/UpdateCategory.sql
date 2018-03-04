CREATE PROCEDURE [dbo].[UpdateCategory]
	 @Name NVARCHAR(15),
	 @Description NTEXT = NULL,
	 @Picture IMAGE = NULL,
	 @Id INT
AS
BEGIN
    UPDATE [dbo].[Categories]
	SET 
	CategoryName= @Name, 
	[Description]= @Description, 
	Picture= @Picture
	WHERE @Id = CategoryID;
	
	SELECT @Id;
END
