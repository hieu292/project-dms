USE [DMS_DB]
GO

/****** Object:  Table [dbo].[dms_SalesOrderDetail]    Script Date: 06/09/2011 23:11:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dms_SalesOrderDetail]') AND type in (N'U'))
DROP TABLE [dbo].[dms_SalesOrderDetail]
GO


/****** Object:  Table [dbo].[dms_SalesOrderDetail]    Script Date: 06/09/2011 22:38:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dms_SalesOrderDetail](
	[SalesOrderNbr] [varchar](10) NOT NULL,
	[ProductID] [varchar](10) NOT NULL,
	[UnitQuantity] [int] NOT NULL,
	[CaseQuantity] [int] NOT NULL,
	[isProm] [varchar](1) NOT NULL,
	[StockID] [varchar](10) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedUser] [varchar](30) NOT NULL,
	[CreatedProg] [varchar](30) NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[UpdatedUser] [varchar](30) NOT NULL,
	[UpdatedProg] [varchar](30) NOT NULL,
 CONSTRAINT [PK_dms_SalesOrderDetail] PRIMARY KEY CLUSTERED 
(
	[SalesOrderNbr] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


