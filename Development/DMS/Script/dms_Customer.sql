USE [DMS_DB]
GO

/****** Object:  Table [dbo].[dms_Customer]    Script Date: 06/09/2011 21:28:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dms_Customer]') AND type in (N'U'))
DROP TABLE [dbo].[dms_Customer]
GO

/****** Object:  Table [dbo].[dms_Customer]    Script Date: 06/09/2011 21:28:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dms_Customer](
	[CustID] [varchar](10) NOT NULL,
	[CustName] [nvarchar](30) NOT NULL,
	[CellPhoneNbr] [varchar](15) NOT NULL,
	[TelePhoneNbr] [varchar](10) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[StreetCode] [varchar](10) NOT NULL,
	[DistCode] [varchar](10) NOT NULL,
	[CityCode] [varchar](10) NOT NULL,
	[Type] [varchar](2) NOT NULL,
	[AccountNbr] [varchar](20) NOT NULL,
	[ShipAddress] [varchar](100) NOT NULL,
	[Status] [varchar](2) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedUser] [varchar](30) NOT NULL,
	[CreatedProg] [varchar](30) NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[UpdatedUser] [varchar](30) NOT NULL,
	[UpdatedProg] [varchar](30) NOT NULL,
 CONSTRAINT [PK_dms_Customer] PRIMARY KEY CLUSTERED 
(
	[CustID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


