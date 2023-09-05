USE [PCES]
GO
/****** Object:  StoredProcedure [dbo].[PCES_OrderTable_INSERT]    Script Date: 2/11/2023 8:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[PCES_OrderTable_INSERT]
	
	(
	@OrderId int,
	@TransactionReference varchar (30),
	@Amount decimal(8,2),
	@Currency varchar (30),
	@Date date ,
	@Status varchar(30)
	)
AS
BEGIN
   BEGIN TRY
      INSERT INTO OrderTable
	   (
	   OrderId,
	   TransactionReference,
	   Amount,
	   Currency,
	   Date,
	   Status
	)

	VALUES
	(
	@OrderId,
	@TransactionReference,
	@Amount,
	@Currency,
	@Date,
	@Status
	)
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
   


 