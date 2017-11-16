SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[tmpspawnedgameobjects]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tmpspawnedgameobjects](
	[gameObject_guid] [bigint] NOT NULL DEFAULT ((19533676560844523.)),
	[gameObject_entry] [int] NOT NULL DEFAULT ((0)),
	[gameObject_rotation1] [float] NOT NULL DEFAULT ((0)),
	[gameObject_rotation2] [float] NOT NULL DEFAULT ((0)),
	[gameObject_rotation3] [float] NOT NULL DEFAULT ((0)),
	[gameObject_rotation4] [float] NOT NULL DEFAULT ((0)),
	[gameObject_positionX] [float] NOT NULL DEFAULT ((0)),
	[gameObject_positionY] [float] NOT NULL DEFAULT ((0)),
	[gameObject_positionZ] [float] NOT NULL DEFAULT ((0)),
	[gameObject_orientation] [float] NOT NULL DEFAULT ((0)),
	[gameObject_map] [smallint] NOT NULL DEFAULT ((0)),
	[gameObject_spawnId] [smallint] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_tmpspawnedgameobjects] PRIMARY KEY CLUSTERED 
(
	[gameObject_guid] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO