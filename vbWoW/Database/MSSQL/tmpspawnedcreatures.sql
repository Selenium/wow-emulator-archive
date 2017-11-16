SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[tmpspawnedcreatures]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tmpspawnedcreatures](
	[spawned_guid] [bigint] NOT NULL DEFAULT ((19533676560844523.)),
	[spawned_positionX] [float] NULL,
	[spawned_positionY] [float] NULL,
	[spawned_positionZ] [float] NULL,
	[spawned_orientation] [float] NULL,
	[spawned_map] [smallint] NULL,
	[spawned_entry] [int] NULL,
	[spawn_id] [int] NULL,
 CONSTRAINT [PK_tmpspawnedcreatures] PRIMARY KEY CLUSTERED 
(
	[spawned_guid] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO