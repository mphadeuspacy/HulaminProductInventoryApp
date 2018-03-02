CREATE PROCEDURE [dbo].[GetProductById]
    @Id INT = 0
AS
    
RETURN SELECT * FROM dbo.Products WHERE @Id = ProductID;
