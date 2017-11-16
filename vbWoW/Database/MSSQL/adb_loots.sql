SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_loots]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_loots](
	[loot_id] [int] IDENTITY(1,1) NOT NULL,
	[loot_item] [smallint] NOT NULL DEFAULT ((0)),
	[loot_chance] [float] NOT NULL DEFAULT ((0)),
	[loot_group] [smallint] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_adb_loots] PRIMARY KEY CLUSTERED 
(
	[loot_id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO