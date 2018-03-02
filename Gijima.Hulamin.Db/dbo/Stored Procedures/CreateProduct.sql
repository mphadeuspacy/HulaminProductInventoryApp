CREATE PROCEDURE [dbo].[CreateProduct]
   
        @Name NVARCHAR(40),   
        @SupplierId INT = NULL,
        @CategoryId INT = NULL,
        @QuantityPerUnit NVARCHAR(20) = NULL,
        @UnitPrice MONEY = NULL,
        @UnitsInStock SMALLINT = NULL,
		@UnitsOnOrder SMALLINT = NULL,
        @ReorderLevel SMALLINT = NULL,
        @Discontinued BIT,
        @IdentityId INT OUT
AS
    INSERT INTO [dbo].[Products]
    SELECT  @Name, @SupplierId, @CategoryId, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued;

    SET @IdentityId = SCOPE_IDENTITY();

RETURN @IdentityId
