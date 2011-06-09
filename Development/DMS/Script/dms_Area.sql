USE [DMS_DB]
GO

/****** Object:  Table [dbo].[dms_Area]    Script Date: 06/09/2011 21:27:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dms_Area]') AND type in (N'U'))
DROP TABLE [dbo].[dms_Area]
GO

/****** Object:  Table [dbo].[dms_Area]    Script Date: 06/09/2011 21:25:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dms_Area](
	[AreaCode] [varchar](10) NOT NULL,
	[AreaName] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedUser] [varchar](30) NOT NULL,
	[CreatedProg] [varchar](30) NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[UpdatedUser] [varchar](30) NOT NULL,
	[UpdatedProg] [varchar](30) NOT NULL,
 CONSTRAINT [PK_dms_Area] PRIMARY KEY CLUSTERED 
(
	[AreaCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


