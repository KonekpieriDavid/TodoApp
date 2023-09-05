USE [Beginner2]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 8/31/2023 8:49:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
 -- Below is the Orders table
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[Price] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

 -- Below is the products table
CREATE TABLE [dbo].[Products](
	[ProductID] [int] NOT NULL,
	[Picture] [varbinary](max) NULL,
	[Title] [varchar](255) NULL,
	[Price] [decimal](10, 2) NULL,
	[Description] [varchar](max) NULL,
	[InsertedBy] [varchar](100) NULL,
	[InsertDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
 -- Below is the sales table
CREATE TABLE [dbo].[Sales](
	[SaleID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[Title] [varchar](255) NULL,
	[Amount] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[SaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
  -- Below is the supplier table
CREATE TABLE [dbo].[SupplierTable](
	[Date] [datetime] NULL,
	[SupplierName] [varchar](255) NULL,
	[ProductSupplied] [varchar](255) NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](10, 2) NULL
) ON [PRIMARY]
GO
