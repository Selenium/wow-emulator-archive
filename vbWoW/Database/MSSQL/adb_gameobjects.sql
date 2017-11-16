SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_gameobjects]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_gameobjects](
	[gameObject_ID] [int] NOT NULL DEFAULT ((0)),
	[gameObject_Size] [float] NOT NULL DEFAULT ((0)),
	[gameObject_Model] [smallint] NOT NULL DEFAULT ((0)),
	[gameObject_Flags] [smallint] NOT NULL DEFAULT ((0)),
	[gameObject_Name] [varchar](255) NOT NULL,
	[gameObject_Type] [tinyint] NOT NULL DEFAULT ((0)),
	[gameObject_Faction] [int] NOT NULL DEFAULT ((0)),
	[gameObject_Sound0] [int] NOT NULL DEFAULT ((0)),
	[gameObject_Sound1] [int] NOT NULL DEFAULT ((0)),
	[gameObject_Sound2] [int] NOT NULL DEFAULT ((0)),
	[gameObject_Sound3] [int] NOT NULL DEFAULT ((0)),
	[gameObject_Sound4] [int] NOT NULL DEFAULT ((0)),
	[gameObject_Sound5] [int] NOT NULL DEFAULT ((0)),
	[gameObject_Sound6] [int] NOT NULL DEFAULT ((0)),
	[gameObject_Sound7] [int] NOT NULL DEFAULT ((0)),
	[gameObject_Sound8] [int] NOT NULL DEFAULT ((0)),
	[gameObject_Sound9] [int] NOT NULL DEFAULT ((0)),
	[gameObject_Loot] [smallint] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_adb_gameobjects] PRIMARY KEY CLUSTERED 
(
	[gameObject_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO