CREATE PROCEDURE [dbo].[CreateSupplier]

        @Name NVARCHAR(40),   
        @ContactName NVARCHAR(30) = NULL,
        @ContactTitle NVARCHAR(30) = NULL,
        @Address NVARCHAR(60) = NULL,
        @City NVARCHAR(15) = NULL,
        @Region NVARCHAR(15) = NULL,
        @PostalCode NVARCHAR(10) = NULL,
        @Country NVARCHAR(15) = NULL,
        @Phone NVARCHAR(24) = NULL,
        @Fax NVARCHAR(24) = NULL,
        @HomePage NTEXT = NUll
AS
BEGIN 
	SET NOCOUNT ON;

    INSERT INTO [dbo].[Suppliers]
    SELECT  @Name, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax, @HomePage;

	SELECT SCOPE_IDENTITY();
END
