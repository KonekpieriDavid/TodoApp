USE [PCES]
GO
/****** Object:  StoredProcedure [dbo].[PCES_SelectAirtimePurchase]    Script Date: 5/5/2023 9:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[PCES_SelectAirtimePurchase]
    @PurchaseID INT = NULL,
    @CustomerId INT = NULL,
    @PhoneNumber VARCHAR(20) = NULL,
	 @Amount DECIMAL(10,2),
	 @PurchaseDate DateTime ,
	 @TeleUserId VARCHAR (50)
AS
BEGIN
 
    SET NOCOUNT ON;
    
    SELECT * FROM AirtimePurchase
    
    WHERE (@PurchaseID IS NULL OR PurchaseID = @PurchaseID)
    AND (@CustomerId  IS NULL OR CustomerId  = @CustomerId )
    AND (@PhoneNumber IS NULL OR PhoneNumber = @PhoneNumber)
	    AND ( @Amount IS NULL OR  Amount =  @Amount)
		AND (@PurchaseDate IS NULL OR PurchaseDate =@PurchaseDate)
	   AND(@TeleUserId IS NULL OR TeleUserId =@TeleUserId)

    
END
