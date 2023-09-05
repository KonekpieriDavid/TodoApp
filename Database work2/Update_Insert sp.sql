----AUTHOR: Konekpieri David
----DATE:5TH DECEMBER,2022
----DESCRIPTION:Creating stored procedure to perform UPDATE_INSERT_DELETE operation
---TIME:12:AM

CREATE OR ALTER PROCEDURE PCES_Orders_INSERT_UPDATE_DELETE		   
 (
 @OrderId int OUTPUT,
 @UserId int=null,
 @Amount decimal(8, 2)=null,
 @Fees decimal(8, 2)=null,
 @Total decimal(8, 2)=null,
 @CreatedWhenUTC datetime=null,
 @Description nvarchar(MAX)=null,
 @Payer varchar(100)=null,
 @OrderStatusId int=null,
 @CreatedBy varchar(100)=null,
 @CreatedDate datetime=null,
 @UpdatedBy varchar(100)=null,
 @UpdatedDate datetime=null,
 @UpdatedDateUTC datetime=null,
 @Action varchar(50)
 )
 AS 
 BEGIN
	IF @Action is null
		BEGIN TRY
		IF( @Amount IS NULL OR  @Payer  IS NULL)
	          RAISERROR('Amount or Payer do not accept null values',15,1)
			IF EXISTS(SELECT 1 FROM dbo.Orders WHERE OrderId=@OrderId)
				BEGIN
                 UPDATE Orders  SET UserId=@UserId,Amount=@Amount,Fees=@Fees,Total=@Total,CreatedWhenUTC=@CreatedWhenUTC,Description=@Description, 
	              Payer=@Payer,OrderStatusId=@OrderStatusId,CreatedBy=@CreatedBy,CreatedDate=@CreatedDate, UpdatedBy=@UpdatedBy,
	              UpdatedDate=@UpdatedDate,UpdatedDateUTC=@UpdatedDateUTC 

	                          WHERE OrderId=@OrderId
                   END

           ELSE 
	                BEGIN
                          INSERT INTO Orders (
	                          UserId,Amount,Fees,Total,CreatedWhenUTC,Description, Payer,OrderStatusId,CreatedBy,CreatedDate, UpdatedBy,
	                                      UpdatedDate,UpdatedDateUTC )
	
	                              VALUES
                                (
                                  @UserId,
                                  @Amount,
	                              @Fees,
                                  @Total,
                                  @CreatedWhenUTC,
                                  @Description,
                                  @Payer,
                                  @OrderStatusId,
                                  @CreatedBy,
                                  @CreatedDate,
                                  @UpdatedBy,
                                  @UpdatedDate,
                                  @UpdatedDateUTC
	                                                )
                         END
	       END TRY
		  
		      BEGIN CATCH
	                 
							PRINT 'Error Message: ' + ERROR_MESSAGE()
	           END CATCH
	       

	else if(@Action<> 'DELETE' )
		RAISERROR( 'Check action type',15,9)

	else if @Action = 'DELETE'
		BEGIN TRY
			DELETE FROM Orders
	        WHERE  OrderId=@OrderId	  
		END TRY
		BEGIN CATCH
			SELECT  
            ERROR_NUMBER() AS ErrorNumber ,
            ERROR_SEVERITY() AS ErrorSeverity , 
            ERROR_STATE() AS ErrorState 			  
		END CATCH
END
		  

		/*
                --update with null values

				
		    EXEC PCES_Orders_INSERT_UPDATE_DELETE @OrderId=9, @UserId=1, @Amount=null, @Fees=200.2,   @Total=221.3, @CreatedWhenUTC='5-DECEMBER 2022', @Description='Debt Payment been made', 

	                         @Payer=null,@OrderStatusId=3, @CreatedBy='Frank',@CreatedDate='5-DECEMBER 2022',  @UpdatedBy='Kojo',

	                             @UpdatedDate='23-December 2022',  @UpdatedDateUTC='6-December 2022',@Action=null


		     --update with no null values
		   EXEC PCES_Orders_INSERT_UPDATE_DELETE @OrderId=11, @UserId=1, @Amount=101, @Fees=200.2,   @Total=300.3, @CreatedWhenUTC='5-DECEMBER 2022', @Description='Debt Payment been made', 
	                @Payer='James',@OrderStatusId=3, @CreatedBy='Frank',@CreatedDate='5-DECEMBER 2022',  @UpdatedBy='Kojo',
	                @UpdatedDate='23-December 2022',  @UpdatedDateUTC='6-December 2022',@Action=null

		   
		     ----Insert with no null values
		    EXEC PCES_Orders_INSERT_UPDATE_DELETE @OrderId=null, @UserId=1, @Amount=101, @Fees=200.2,   @Total=300.3, @CreatedWhenUTC='5-DECEMBER 2022', @Description='Debt Payment been made', 
	                @Payer='Abraham',@OrderStatusId=3, @CreatedBy='Frank',@CreatedDate='5-DECEMBER 2022',  @UpdatedBy='Kojo',
	                @UpdatedDate='23-December 2022',  @UpdatedDateUTC='6-December 2022',@Action=null

					----Insert with null values
					 EXEC PCES_Orders_INSERT_UPDATE_DELETE @OrderId=null, @UserId=2, @Amount=null, @Fees=200.2,   @Total=300.3, @CreatedWhenUTC='5-DECEMBER 2022', @Description='Debt Payment been made', 
	                @Payer=null,@OrderStatusId=3, @CreatedBy='Frank',@CreatedDate='5-DECEMBER 2022',  @UpdatedBy='Kojo',
	                @UpdatedDate='23-December 2022',  @UpdatedDateUTC='6-December 2022',@Action=null


						----This is DELETE  with the delete action type and  specified OrderId	 
                    	    EXEC PCES_Orders_INSERT_UPDATE_DELETE   @OrderId=17, @Action='DELETE'

				
				----This is DELETE  with the incorrect delete action type and  specified OrderId	 
                    	    EXEC PCES_Orders_INSERT_UPDATE_DELETE   @OrderId=10, @Action='DELE'
				
		   */


		  