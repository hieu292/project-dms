USE [DMS]
GO

/****** Object:  Table [dbo].[dms_SalesOrderHeader]    Script Date: 06/03/2011 00:44:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dms_SalesOrderHeader]') AND type in (N'U'))
DROP TABLE [dbo].[dms_SalesOrderHeader]
GO

/****** Object:  Table [dbo].[dms_SalesOrderHeader]    Script Date: 06/03/2011 00:43:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dms_SalesOrderHeader](
	[OrderID] [varchar](10) NOT NULL,
	[OutletID] [varchar](10) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[OrderType] [varchar](2) NOT NULL,
	[SalesmanID] [varchar](10) NOT NULL,
	[Status] [varchar](2) NOT NULL,
 CONSTRAINT [PK_dms_SalesOrderHeader] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


