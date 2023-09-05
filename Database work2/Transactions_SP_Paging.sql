USE [PaymentPlatformV2]
GO
/****** Object:  StoredProcedure [dbo].[PCES_Orders_SELECTPages]    Script Date: 12/22/2022 8:31:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[PCES_Orders_SELECTPages]
@Page int,
@Size int
  AS 
 BEGIN
 
 BEGIN TRY
	 
        SELECT 
		OrderId,
		UserId,
		Amount,
		Fees,
		Total,
		CreatedWhenUTC,
		Description,
	     Payer,
		 OrderStatusId, 
		 CreatedBy, 
		 CreatedDate,
		 UpdatedBy,
		 UpdatedDate,
		 UpdatedDateUTC

	 FROM Orders

     ORDER BY OrderId
	 OFFSET (@Page -1) * @Size ROW
	 FETCH NEXT @Size ROWS ONLY
       
 END TRY
 BEGIN CATCH
	PRINT 'Error Message: ' + ERROR_MESSAGE()
 END CATCH
  END

   /*page1 should contain a size of 5 items from Orders */
  execute dbo.PCES_Orders_SELECTPages @Page=1, @Size=5
