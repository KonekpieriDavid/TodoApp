USE [PCES]
GO
/****** Object:  StoredProcedure [dbo].[PCES_Orders_INSERT]   
     Script Date: 1/3/2023 8:20:09 AM 
	 Author: David
----DESCRIPTION:Creating stored procedure to perform INSERT operation
---TIME:12:AM******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PCES_Orders_INSERT]
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
    INSERT INTO Orders
	    (
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
		)
	
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





SELECT * FROM dbo.Orders




       EXEC PCES_Orders_INSERT 
	  
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