SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[tmpspawnedcoprses]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tmpspawnedcoprses](
	[corpse_guid] [bigint] NOT NULL DEFAULT ((19533676560844523.)),
	[corpse_owner] [bigint] NOT NULL DEFAULT ((19533676560844523.)),
	[corpse_positionX] [float] NOT NULL DEFAULT ((0)),
	[corpse_positionY] [float] NOT NULL DEFAULT ((0)),
	[corpse_positionZ] [float] NOT NULL DEFAULT ((0)),
	[corpse_orientation] [float] NOT NULL DEFAULT ((0)),
	[corpse_mapId] [smallint] NOT NULL DEFAULT ((0)),
	[corpse_bytes1] [int] NOT NULL DEFAULT ((0)),
	[corpse_bytes2] [int] NOT NULL DEFAULT ((0)),
	[corpse_model] [smallint] NOT NULL DEFAULT ((0)),
	[corpse_guild] [smallint] NOT NULL DEFAULT ((0)),
	[corpse_items] [varchar](255) NOT NULL,
 CONSTRAINT [PK_tmpspawnedcoprses] PRIMARY KEY CLUSTERED 
(
	[corpse_guid] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO