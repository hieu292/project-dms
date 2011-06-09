USE [DMS_DB]
GO

/****** Object:  Table [dbo].[dms_City]    Script Date: 06/10/2011 00:12:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dms_City]') AND type in (N'U'))
DROP TABLE [dbo].[dms_City]
GO

/****** Object:  Table [dbo].[dms_City]    Script Date: 06/10/2011 00:12:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dms_City](
	[CityCode] [varchar](10) NOT NULL,
	[CityName] [nvarchar](30) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedUser] [varchar](30) NOT NULL,
	[CreatedProg] [varchar](30) NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[UpdatedUser] [varchar](30) NOT NULL,
	[UpdatedProg] [varchar](30) NOT NULL,
 CONSTRAINT [PK_dms_City] PRIMARY KEY CLUSTERED 
(
	[CityCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


