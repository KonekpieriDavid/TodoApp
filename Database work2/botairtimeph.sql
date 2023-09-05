CREATE OR ALTER PROCEDURE RecordAirtimePurchase
(
    @TeleUserId  VARCHAR(50),
	
    @PhoneNumber VARCHAR(20),
	@PurchaseId VARCHAR (50),
    @Amount DECIMAL(10,2)
	
	)
AS
BEGIN
    SET NOCOUNT ON;
    

	DECLARE @CustomerId  INT ;

    -- Insert the new purchase into the AirtimePurchase table
    INSERT INTO AirtimePurchase (    TeleUserId, PhoneNumber, Amount,PurchaseId, PurchaseDate) 
    VALUES (    @TeleUserId, @PhoneNumber,@Amount,@PurchaseId, GETDATE());
    
    -- Get the PurchaseId of the newly inserted record
    SELECT @CustomerId  = SCOPE_IDENTITY();
	

    -- Return the PurchaseId to the caller
  
	  SELECT SCOPE_IDENTITY() AS 'CustomerId';
END

EXEC RecordAirtimePurchase 

	
	@TeleUserId = '1990034567890', 
	@PurchaseId = 1,
	
	@PhoneNumber = '44853012678', 
	@Amount = 53.00;
	SELECT * FROM AirtimePurchase
	-- not the the customerId in the RecordAirtimePurchase must be same as CustomerTable