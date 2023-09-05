USE [PCES]
GO
/****** Object:  StoredProcedure [dbo].[PCES_TransactionAPITest_INSERT]    Script Date: 1/25/2023 8:13:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE  PROCEDURE dbo.PCES_GetAllOrder
 
AS
BEGIN
   BEGIN TRY
      SELECT 
	   
	   OrderId,
	   CustomerFullName,
	   CustomerPhoneNumber,
	   customerEmailAddress,
	   TransactionReference,
	   Amount,
	   Currency,
	   Date,
	   Status

	     FROM OrderTable
		
		 
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




