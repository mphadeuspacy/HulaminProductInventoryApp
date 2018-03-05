CREATE PROCEDURE [dbo].[DeleteSupplier]
    @Id int
AS
BEGIN
    DELETE FROM dbo.Suppliers WHERE @Id = SupplierID;

    SELECT @Id;
END