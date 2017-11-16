SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_characters_quests]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_characters_quests](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[char_guid] [bigint] NOT NULL DEFAULT ((19533676560844523.)),
	[quest_id] [int] NOT NULL DEFAULT ((0)),
	[quest_status] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_adb_characters_quests] PRIMARY KEY CLUSTERED 
(
	[id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO