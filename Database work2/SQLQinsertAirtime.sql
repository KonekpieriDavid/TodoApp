USE [PCES]
GO
/****** Object:  StoredProcedure [dbo].[PCES_InsertAirtimePurchase]    Script Date: 5/5/2023 8:58:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[PCES_InsertAirtimePurchase]
(
  
    @CustomerId INT,
    @TeleUserId VARCHAR(50),
    @PhoneNumber VARCHAR(20),
    @Amount DECIMAL(10,2)
   
	)
AS
BEGIN 
BEGIN TRY
    SET NOCOUNT ON;
    SET IDENTITY_INSERT AirtimePurchase ON;
    --Check if CustomerName is provided
    IF (@PhoneNumber IS NULL)
	  
    BEGIN
        RAISERROR('PhoneNumber cannot be null or empty', 16, 1)
        RETURN;
    END
    
    -- Check if PhoneNumber is provided
    IF (@Amount IS NULL )
    BEGIN
        RAISERROR('Amount cannot be null or empty', 16, 1)
        RETURN;
    END
    
    -- Check if Amount is provided
    IF (@Amount IS NULL)
    BEGIN
        RAISERROR('Amount cannot be null', 16, 1)
        RETURN;
    END
    -- Check if Amount is greater than zero
    IF (@Amount <= 0)
    BEGIN
        RAISERROR('Amount must be greater than zero', 16, 1)
        RETURN;
    END
    
    INSERT INTO AirtimePurchase 
	              (
				 CustomerId,
				  TeleUserId,
				  PhoneNumber, 
				  Amount 
				  
				  )

    VALUES (
	   @CustomerId,
		@TeleUserId,
		@PhoneNumber, 
		@Amount
		
		)
    
    SELECT SCOPE_IDENTITY() AS 'PurchaseID';
			 
	END TRY

	BEGIN CATCH
	
	        SELECT  
                       ERROR_NUMBER() AS ErrorNumber  
                        ,ERROR_SEVERITY() AS ErrorSeverity  
                       ,ERROR_STATE() AS ErrorState  
                       ,ERROR_PROCEDURE() AS ErrorProcedure  
                        ,ERROR_LINE() AS ErrorLine  
                        ,ERROR_MESSAGE() AS ErrorMessage; 
	END CATCH
	

END
	Exec PCES_InsertAirtimePurchase @CustomerId=3, @TeleUserId='13332222',@PhoneNumber='0546458722',@Amount=234;

	SELECT * FROM AirtimePurchase
	SELECT * FROM CustomerTable