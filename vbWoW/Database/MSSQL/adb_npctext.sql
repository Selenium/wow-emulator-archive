SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_npctext]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_npctext](
	[text_id] [smallint] NOT NULL DEFAULT ((0)),
	[text_dens_0] [tinyint] NOT NULL DEFAULT ((0)),
	[text_text_0_1] [varchar](255) NOT NULL,
	[text_text_0_2] [varchar](255) NOT NULL,
	[text_lang_0] [tinyint] NOT NULL DEFAULT ((0)),
	[text_emote_0_1] [smallint] NOT NULL DEFAULT ((0)),
	[text_delay_0_1] [smallint] NOT NULL DEFAULT ((0)),
	[text_emote_0_2] [smallint] NOT NULL DEFAULT ((0)),
	[text_delay_0_2] [smallint] NOT NULL DEFAULT ((0)),
	[text_emote_0_3] [smallint] NOT NULL DEFAULT ((0)),
	[text_delay_0_3] [smallint] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_adb_npctext] PRIMARY KEY CLUSTERED 
(
	[text_id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO