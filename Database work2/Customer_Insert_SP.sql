
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE or ALTER PROCEDURE dbo.PCES_OrderTable_INSERT
	
	(
	@OrderId int,
	@CustomerFullName varchar (30),
	@CustomerPhoneNumber varchar (30),
	@CustomerEmailAddress varchar (30),
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
	   CustomerFullName,
	   CustomerPhoneNumber,
	   customerEmailAddress,
	   TransactionReference,
	   Amount,
	   Currency,
	   Date,
	   Status
	)

	VALUES
	(
	@OrderId,
	@CustomerFullName,
	@CustomerPhoneNumber,
	@CustomerEmailAddress,
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

EXEC dbo.PCES_OrderTable_INSERT
   @OrderId=1,
   @CustomerFullname="Fred Ben",
   @CustomerPhoneNumber="0543216723",
   @CustomerEmailAddress ="fojbe@gmail.com",
	@TransactionReference="myreferece22",
	@Amount =21.0,
	@Currency ="GHS",
	@Date ='1/1/1910' ,
	@Status="Active"

	SELECT * FROM  OrderTable