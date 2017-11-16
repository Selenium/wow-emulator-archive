SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_spawns]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_spawns](
	[spawn_id] [int] IDENTITY(1,1) NOT NULL,
	[spawn_entry] [int] NOT NULL DEFAULT ((0)),
	[spawn_time] [smallint] NOT NULL DEFAULT ((0)),
	[spawn_positionX] [float] NOT NULL DEFAULT ((0)),
	[spawn_positionY] [float] NOT NULL DEFAULT ((0)),
	[spawn_positionZ] [float] NOT NULL DEFAULT ((0)),
	[spawn_orientation] [float] NOT NULL DEFAULT ((0)),
	[spawn_spawned] [tinyint] NOT NULL DEFAULT ((0)),
	[spawn_range] [smallint] NOT NULL DEFAULT ((0)),
	[spawn_type] [tinyint] NOT NULL DEFAULT ((0)),
	[spawn_map] [smallint] NOT NULL DEFAULT ((0)),
	[spawn_left] [smallint] NOT NULL DEFAULT ((0)),
	[spawn_waypoints] [smallint] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_adb_spawns] PRIMARY KEY CLUSTERED 
(
	[spawn_id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO