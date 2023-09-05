USE [PCES]
GO

/****** Object:  Table [dbo].[TransactionAPITest]    Script Date: 1/25/2023 12:01:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TransactionAPITest](
	[CustomerId] [int] NULL,
	[CustomerFullName] [varchar](30) NULL,
	[CustomerPhoneNumber] [varchar](30) NULL,
	[CustomerEmailAddress] [varchar](30) NULL,
	[TransactionReference] [varchar](30) NULL,
	[Amount] [decimal](8, 2) NULL,
	[Currency] [varchar](30) NULL
) ON [PRIMARY]
GO


