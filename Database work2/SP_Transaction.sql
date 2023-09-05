USE [PaymentPlatformV2]
GO

/****** Object:  Table [dbo].[Transactions]    Script Date: 12/21/2022 2:22:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure PCES_Transactions_INSERT_SELECT_PAGES


(
	@TransactionId int IDENTITY(1,1) NOT NULL,
	@OrderId int NOT NULL,
	@TransactionTypeID int NOT NULL,
	@ValueDate date NOT NULL,
	@EntryCount int NOT NULL,
	@RegistrationDate smalldatetime NOT NULL,
	@TransactionReason varchar(100) NOT NULL,
	@ReversalId] int NULL,
	@InsertedBy varchar(30) NOT NULL,
	@UpdatedBy varchar(30) NOT NULL,
	@InsertDate datetime NOT NULL,
	@UpdateDate datetime NOT NULL,
 )
 AS
BEGIN

 END
