USE [PaymentPlatformV2]
GO
/****** Object:  StoredProcedure [dbo].[PCES_Transactions_INSERT_SELECT_PAGES]    Script Date: 12/22/2022 8:30:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  OR ALTER  PROCEDURE dbo.PCES_Transactions_INSERT_SELECT_LISTPAGES


(
   @Page int,
   @Size int
 )

  AS
BEGIN
 BEGIN TRY
       SELECT
	TransactionId,
	  OrderId,
	  TransactionTypeID,
	  ValueDate,
	  EntryCount ,
	  RegistrationDate,
	  TransactionReason,
	  ReversalId,
	  InsertedBy,
	  UpdatedBy ,
	  InsertDate,
	  UpdateDate
	  

	  FROM Transactions

     ORDER BY TransactionId
	 OFFSET (@Page -1) * @Size ROW
	 FETCH NEXT @Size ROWS ONLY

	


    END TRY

  BEGIN CATCH
     SELECT  
             ERROR_NUMBER() AS ErrorNumber, 
              ERROR_MESSAGE () AS Errormessage,  
              ERROR_LINE() AS ErrorLine 
  END CATCH
   END

      /*page1 should contain a size of 5 items from Transaction table */
  execute dbo.PCES_Transactions_INSERT_SELECT_LISTPAGES @Page=1, @Size=5
