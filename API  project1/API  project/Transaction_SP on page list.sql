USE [PaymentPlatformV2]
GO
/****** Object:  StoredProcedure [dbo].[PCES_Transactions_INSERT_SELECT_PAGES]    Script Date: 12/23/2022 8:55:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER    PROCEDURE [dbo].[PCES_Transactions_INSERT_SELECT_PAGES]


(
    @TransactionId int,
	@OrderId int ,
	@TransactionTypeID int ,
	@ValueDate date ,
	@EntryCount int ,
	@RegistrationDate smalldatetime ,
	@TransactionReason varchar(100) ,
	@ReversalId int ,
	@InsertedBy varchar(30) ,
	@UpdatedBy varchar(30) ,
	@InsertDate datetime ,
	@UpdateDate datetime 
 )

  AS
BEGIN
 BEGIN TRY
      INSERT INTO Transactions

	  (
	 
	  OrderId,
	  TransactionTypeID,
	  ValueDate,
	  EntryCount ,
	  RegistrationDate,
	  TransactionReason,
	  ReversalId,
	  InsertedBy,
	  UpdatedBy ,
	  InsertDate,
	  UpdateDate
	  )

	  VALUES

	  (
	  @OrderId,
	  @TransactionTypeID,
	  @ValueDate,
	  @EntryCount ,
	  @RegistrationDate,
	  @TransactionReason,
	  @ReversalId,
	  @InsertedBy,
	  @UpdatedBy,
	  @InsertDate,
	  @UpdateDate
	  )


    END TRY

  BEGIN CATCH
     SELECT  
             ERROR_NUMBER() AS ErrorNumber, 
              ERROR_MESSAGE () AS Errormessage,  
              ERROR_LINE() AS ErrorLine 
  END CATCH
   END