CREATE PROCEDURE [dbo].[UpdateProduct]
	
        @Name NVARCHAR(40),   
        @SupplierId INT = NULL,
        @CategoryId INT = NULL,
        @QuantityPerUnit NVARCHAR(20) = NULL,
        @UnitPrice MONEY = NULL,
        @UnitsInStock SMALLINT = NULL,
		@UnitsOnOrder SMALLINT = NULL,
        @ReorderLevel SMALLINT = NULL,
        @Discontinued BIT,
		@Id INT
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE [dbo].[Products]
	SET 
	ProductName= @Name, 
	SupplierID= @SupplierId, 
	CategoryID= @CategoryId, 
	QuantityPerUnit= @QuantityPerUnit, 
	UnitPrice= @UnitPrice, 
	UnitsInStock= @UnitsInStock, 
	UnitsOnOrder= @UnitsOnOrder, 
	ReorderLevel= @ReorderLevel, 
	Discontinued= @Discontinued
	WHERE @Id = ProductID;
	
	SELECT @Id;
END
