USE [DMS_DB]
GO

/****** Object:  Table [dbo].[dms_SalesOrderHeader]    Script Date: 06/09/2011 22:26:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dms_SalesOrderHeader]') AND type in (N'U'))
DROP TABLE [dbo].[dms_SalesOrderHeader]
GO


/****** Object:  Table [dbo].[dms_SalesOrderHeader]    Script Date: 06/09/2011 22:02:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dms_SalesOrderHeader](
	[SalesOrderNbr] [varchar](10) NOT NULL,
	[PDACode] [varchar](10) NOT NULL,
	[CustID] [varchar](10) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[OrderType] [varchar](2) NOT NULL,
	[SlsperSell] [varchar](10) NOT NULL,
	[SlsperPay] [varchar](10) NOT NULL,
	[SlsperDelivery] [varchar](10) NOT NULL,
	[Commission] [float] NOT NULL,
	[DueDate] [int] NULL,
	[Status] [varchar](2) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedUser] [varchar](30) NOT NULL,
	[CreatedProg] [varchar](30) NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[UpdatedUser] [varchar](30) NOT NULL,
	[UpdatedProg] [varchar](30) NOT NULL,
 CONSTRAINT [PK_dms_SalesOrderHeader] PRIMARY KEY CLUSTERED 
(
	[SalesOrderNbr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


