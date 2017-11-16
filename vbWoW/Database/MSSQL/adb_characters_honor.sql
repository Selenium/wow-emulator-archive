SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_characters_honor]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_characters_honor](
	[char_guid] [bigint] NOT NULL DEFAULT ((19533676560844523.)),
	[arena_currency] [smallint] NOT NULL DEFAULT ((0)),
	[honor_currency] [smallint] NOT NULL DEFAULT ((0)),
	[honor_title] [tinyint] NOT NULL DEFAULT ((0)),
	[honor_knownTitles] [smallint] NOT NULL DEFAULT ((0)),
	[honor_killsToday] [smallint] NOT NULL DEFAULT ((0)),
	[honor_killsYesterday] [smallint] NOT NULL DEFAULT ((0)),
	[honor_pointsToday] [smallint] NOT NULL DEFAULT ((0)),
	[honor_pointsYesterday] [smallint] NOT NULL DEFAULT ((0)),
	[honor_kills] [tinyint] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_adb_characters_honor] PRIMARY KEY CLUSTERED 
(
	[char_guid] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO