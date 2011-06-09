USE [DMS_DB]
GO

/****** Object:  Table [dbo].[dms_Product]    Script Date: 06/09/2011 21:30:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dms_Product]') AND type in (N'U'))
DROP TABLE [dbo].[dms_Product]
GO

/****** Object:  Table [dbo].[dms_Product]    Script Date: 06/09/2011 21:30:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dms_Product](
	[ProductID] [varchar](10) NOT NULL,
	[Descr] [nvarchar](100) NOT NULL,
	[ShortDescr] [nvarchar](100) NOT NULL,
	[Weight] [float] NOT NULL,
	[Length] [float] NOT NULL,
	[Width] [float] NOT NULL,
	[Height] [float] NOT NULL,
	[BoughtPrice] decimal(18, 0) NOT NULL,
	[SoldPrice] decimal(18, 0) NOT NULL,
	[UnitConvertsion1] [varchar](3) NOT NULL,
	[UnitConvertsion2] [varchar](3) NOT NULL,
	[Coefficient] [int] NOT NULL,
	[TaxCode] [varchar](10) NOT NULL,
	[CatalogLevel1ID] [varchar](10) NOT NULL,
	[CatalogLevel2ID] [varchar](10) NOT NULL,
	[CatalogLevel3ID] [varchar](10) NOT NULL,
	[CatalogLevel4ID] [varchar](10) NOT NULL,
	[CatalogLevel5ID] [varchar](10) NOT NULL,
	[Status] [varchar](2) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedUser] [varchar](30) NOT NULL,
	[CreatedProg] [varchar](30) NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[UpdatedUser] [varchar](30) NOT NULL,
	[UpdatedProg] [varchar](30) NOT NULL,
 CONSTRAINT [PK_dms_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


