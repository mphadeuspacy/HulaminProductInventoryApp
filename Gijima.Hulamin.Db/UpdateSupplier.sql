CREATE PROCEDURE [dbo].[UpdateSupplier]
	
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
        @HomePage NTEXT = NUll,
		@Id INT
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE [dbo].[Suppliers]
	SET 
	CompanyName = @Name, 
	ContactName = @ContactName, 
	ContactTitle = @ContactTitle, 
	[Address]= @Address, 
	City = @City, 
	Region = @Region, 
	PostalCode = @PostalCode, 
	Country = @Country, 	
	Phone = @Phone,
	HomePage = @HomePage
	WHERE @Id = SupplierID;
	
	SELECT @Id;
END
