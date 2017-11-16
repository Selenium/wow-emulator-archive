SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_realms]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_realms](
	[ws_name] [varchar](50) NOT NULL,
	[ws_host] [varchar](50) NOT NULL,
	[ws_port] [int] NOT NULL DEFAULT ((0)),
	[ws_status] [tinyint] NOT NULL DEFAULT ((0)),
	[ws_id] [tinyint] NOT NULL DEFAULT ((0)),
	[ws_type] [tinyint] NOT NULL DEFAULT ((0)),
	[ws_population] [real] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_adb_realms] PRIMARY KEY CLUSTERED 
(
	[ws_id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO