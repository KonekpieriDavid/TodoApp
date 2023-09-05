USE [PaymentPlatformV2]
GO


   ----AUTHOR: Konekpieri David
----DATE:20TH December,2022
----DESCRIPTION:Creating stored procedure to perform SELECT operation
---TIME:12:AM
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE dbo.PCES_Orders_SELECTORDERS_LIST
  AS 
   
  BEGIN
    
    
 BEGIN TRY

	 SELECT TOP 7  
	 OrderId,
	 Amount,
	 Total,
	 Fees,
	 Payer,
	 OrderStatusId, 
	 CreatedBy,
	 CreatedDate
      
         FROM Orders

		 ORDER BY Amount DESC

 END TRY
 BEGIN CATCH
	PRINT 'Error Message: ' + ERROR_MESSAGE()
 END CATCH
  END

 
 

 
   --sp_helptext PCES_Orders_SELECTORDERS_LIST;