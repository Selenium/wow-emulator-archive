SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_bans]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_bans](
	[ip] [varchar](255) NOT NULL DEFAULT (''),
	[date] [varchar](10) NOT NULL DEFAULT ('00-00-0000'),
	[reason] [varchar](255) NOT NULL,
	[who] [varchar](255) NOT NULL,
 CONSTRAINT [PK_adb_bans] PRIMARY KEY CLUSTERED 
(
	[ip] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO