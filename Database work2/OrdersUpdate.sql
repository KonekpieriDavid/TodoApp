USE [PaymentPlatformV2]
GO
/****** Object:  StoredProcedure [dbo].[PCES_Orders_UPDATE]    Script Date: 1/3/2023 9:02:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PCES_Orders_UPDATE]
    (
	   @OrderId int,
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
     UPDATE Orders  SET 
	 UserId=@UserId,
	 Amount=@Amount,
	 Fees=@Fees,
	 Total=@Total,
	 CreatedWhenUTC=@CreatedWhenUTC,
	 Description=@Description, 
	 Payer=@Payer,
	 OrderStatusId=@OrderStatusId,
	 CreatedBy=@CreatedBy,
	 CreatedDate=@CreatedDate,
	 UpdatedBy=@UpdatedBy,
	UpdatedDate=@UpdatedDate,
	UpdatedDateUTC=@UpdatedDateUTC 

	      WHERE OrderId=@OrderId
  END


/*

 EXEC  dbo.PCES_Orders_UPDATE
      @OrderId=18,
	   @UserId=1,
	   @Amount=21.1,
	   @Fees=200.2,
	   @Total=221.3,
	   @CreatedWhenUTC='23-November 2022',
	   @Description='fess Payment been made',  
	   @Payer='David', 
	   @OrderStatusId=3,
	   @CreatedBy='David',
	   @CreatedDate='23-November 2022',
	   @UpdatedBy='David',
	   @UpdatedDate='23-December 2022', 
	   @UpdatedDateUTC='23-December 2022'

 */