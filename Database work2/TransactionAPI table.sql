USE [PCES]
GO

/****** Object:  Table [dbo].[farmer]    Script Date: 1/22/2023 10:37:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE    TABLE TransactionAPITest
(
CustomerId int,
 CustomerFullName varchar(30),
CustomerPhoneNumber varchar(30),
 CustomerEmailAddress varchar (30),
 TransactionReference varchar(30),
 Amount decimal(8,2),
 Currency varchar (30)
)
 INSERT INTO TransactionAPITest
 (
 CustomerId,
 CustomerFullName
 ,CustomerPhoneNumber,
 CustomerEmailAddress, 
 TransactionReference, 
 Amount, 
 Currency
 )
VALUES
(

1,'Paul Bebpe','0549872136','pualb@gmail.com','Erss5432',202.1,'GHS'
)


/*SELECt * FROM TransactionAPIs


