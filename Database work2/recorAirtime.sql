USE [PCES]
GO
/****** Object:  StoredProcedure [dbo].[RecordAirtimePurchase]    Script Date: 5/5/2023 9:05:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[RecordAirtimePurchase]
(
   
    @TeleUserId  VARCHAR(50),
	@CustomerId INT,
    @PhoneNumber VARCHAR(20),

    @Amount DECIMAL(10,2)
	
	)
AS
BEGIN
    SET NOCOUNT ON;
    

	--SET IDENTITY_INSERT AirtimePurchase ON;
	  DECLARE @PurchaseId INT;

    -- Insert the new purchase into the AirtimePurchase table
    INSERT INTO AirtimePurchase (  CustomerId, 	 TeleUserId, PhoneNumber, Amount, PurchaseDate) 
    VALUES (   @CustomerId,  @TeleUserId, @PhoneNumber,@Amount, GETDATE());
    
  -- Get the PurchaseId of the newly inserted record
   
     SELECT SCOPE_IDENTITY();

    -- Return the PurchaseId to the caller
    SELECT @PurchaseId AS 'PurchaseId';
	

END
	Exec RecordAirtimePurchase  @CustomerId=2,@TeleUserId='10111111',@PhoneNumber='05222222222',@Amount=222;

	SELECT * FROM  AirtimePurchase