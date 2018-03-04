CREATE PROCEDURE [dbo].[GetSupplierById]
	@Id INT = 0
AS
BEGIN
	SELECT * FROM [dbo].[Suppliers] WHERE @Id = SupplierID
END
