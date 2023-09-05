USE [PaymentPlatformV2]
GO
/****** Object:  StoredProcedure [dbo].[PCES_Orders_INSERT_UPDATE_DELETE]    Script Date: 12/5/2022 9:29:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PCES_Orders_INSERT_UPDATE_DELETE]
    (
      @UserId int,
      @Amount decimal(8, 2),
      @Fees decimal(8, 2),
      @Total decimal(8, 2),
      @CreatedWhenUTC datetime,
      @Description nvarchar(MAX),
      @Payer varchar(100),
      @OrderStatusId int,
      @CreatedBy varchar(100),
      @CreatedDate datetime,
      @UpdatedBy varchar(100),
      @UpdatedDate datetime,
      @UpdatedDateUTC datetime
	  )
AS
BEGIN
     BEGIN TRY
         IF( @Amount IS NULL OR  @Payer  IS NULL)
			
	          RAISERROR('Amount and Payer do not accept null values',15,1)

            IF EXISTS(SELECT 1 FROM dbo.Orders WHERE UserId=@UserId)
                 INSERT INTO Orders (
	                         UserId,Amount,Fees,Total,CreatedWhenUTC,Description, Payer,OrderStatusId,CreatedBy,CreatedDate, UpdatedBy,
	                                      UpdatedDate,UpdatedDateUTC )
	
	       VALUES
	
	                ( @UserId,
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
	             SELECT  
                        ERROR_NUMBER() AS ErrorNumber  
                        ,ERROR_SEVERITY() AS ErrorSeverity  
                       ,ERROR_STATE() AS ErrorState  
                       ,ERROR_PROCEDURE() AS ErrorProcedure  
                        ,ERROR_LINE() AS ErrorLine  
                        ,ERROR_MESSAGE() AS ErrorMessage; 
	  END CATCH
