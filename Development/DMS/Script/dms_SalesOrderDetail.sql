USE [DMS]
GO

/****** Object:  Table [dbo].[dms_SalesOrderDetail]    Script Date: 06/03/2011 00:45:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dms_SalesOrderDetail]') AND type in (N'U'))
DROP TABLE [dbo].[dms_SalesOrderDetail]
GO



/****** Object:  Table [dbo].[dms_SalesOrderDetail]    Script Date: 06/03/2011 00:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dms_SalesOrderDetail](
	[OrderID] [varchar](10) NOT NULL,
	[ProductID] [varchar](10) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Type] [varchar](2) NOT NULL,
 CONSTRAINT [PK_dms_SalesOrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


