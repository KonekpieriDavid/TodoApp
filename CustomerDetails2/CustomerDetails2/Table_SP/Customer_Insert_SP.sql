
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE or ALTER PROCEDURE dbo.PCES_TransactionAPITest_INSERT
	
	(
	@CustomerId int,
	@CustomerFullName varchar (50),
	@CustomerPhoneNumber varchar (50),
	@CustomerEmailAddress varchar (50),
	@TransactionReference varchar (50),
	@Amount decimal(8,2),
	@Currency varchar (50)
	)
AS
BEGIN
   BEGIN TRY
      INSERT INTO TransactionAPITest
	   (
	   CustomerId,
	   CustomerFullName,
	   CustomerPhoneNumber,
	   customerEmailAddress,
	   TransactionReference,
	   Amount,
	   Currency
	)

	VALUES
	(
	@CustomerId,
	@CustomerFullName,
	@CustomerPhoneNumber,
	@CustomerEmailAddress,
	@TransactionReference,
	@Amount,
	@Currency
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

