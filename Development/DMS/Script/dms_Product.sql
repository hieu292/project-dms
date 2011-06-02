USE [DMS]
GO

/****** Object:  Table [dbo].[dms_Product]    Script Date: 06/03/2011 00:45:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dms_Product]') AND type in (N'U'))
DROP TABLE [dbo].[dms_Product]
GO


/****** Object:  Table [dbo].[dms_Product]    Script Date: 06/03/2011 00:45:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dms_Product](
	[ProductID] [varchar](10) NOT NULL,
	[Descr] [varchar](100) NOT NULL,
	[Price] [float] NOT NULL,
	[CatalogID] [varchar](10) NOT NULL,
	[Status] [varchar](2) NOT NULL,
 CONSTRAINT [PK_dms_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


