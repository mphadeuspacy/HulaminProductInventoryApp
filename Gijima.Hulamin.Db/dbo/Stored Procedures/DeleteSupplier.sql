CREATE PROCEDURE [dbo].[DeleteSupplier]
    @Id INT
AS
BEGIN

    DELETE FROM dbo.Products WHERE @Id = SupplierID;

    DELETE FROM dbo.Suppliers WHERE @Id = SupplierID;

    SELECT @Id;
END