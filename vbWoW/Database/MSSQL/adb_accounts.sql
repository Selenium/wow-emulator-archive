SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_accounts]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_accounts](
	[account] [varchar](30) NOT NULL,
	[password] [varchar](30) NOT NULL,
	[plevel] [tinyint] NOT NULL DEFAULT ((0)),
	[email] [varchar](50) NOT NULL,
	[joindate] [varchar](10) NOT NULL DEFAULT ('00-00-0000'),
	[last_sshash] [varchar](90) NOT NULL,
	[last_ip] [varchar](15) NOT NULL,
	[last_login] [varchar](100) NOT NULL DEFAULT ('0000-00-00'),
	[banned] [tinyint] NOT NULL DEFAULT ((0)),
	[expansion] [tinyint] NOT NULL DEFAULT ((1)),
	[account_id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_adb_accounts] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO