SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_characters]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_characters](
	[account_id] [int] NOT NULL DEFAULT ((0)),
	[char_guid] [int] IDENTITY(1,1) NOT NULL,
	[char_name] [varchar](21) NOT NULL,
	[char_level] [tinyint] NOT NULL DEFAULT ((0)),
	[char_xp] [int] NOT NULL DEFAULT ((0)),
	[char_access] [tinyint] NOT NULL DEFAULT ((0)),
	[char_online] [tinyint] NOT NULL DEFAULT ((0)),
	[char_positionX] [real] NOT NULL DEFAULT ((0)),
	[char_positionY] [real] NOT NULL DEFAULT ((0)),
	[char_positionZ] [real] NOT NULL DEFAULT ((0)),
	[char_map_id] [smallint] NOT NULL DEFAULT ((0)),
	[char_zone_id] [smallint] NOT NULL DEFAULT ((0)),
	[char_orientation] [real] NOT NULL DEFAULT ((0)),
	[char_model] [smallint] NOT NULL DEFAULT ((0)),
	[bindpoint_positionX] [real] NOT NULL DEFAULT ((0)),
	[bindpoint_positionY] [real] NOT NULL DEFAULT ((0)),
	[bindpoint_positionZ] [real] NOT NULL DEFAULT ((0)),
	[bindpoint_map_id] [smallint] NOT NULL DEFAULT ((0)),
	[bindpoint_zone_id] [smallint] NOT NULL DEFAULT ((0)),
	[char_guildId] [int] NOT NULL DEFAULT ((0)),
	[char_guildRank] [tinyint] NOT NULL DEFAULT ((0)),
	[char_guildPNote] [varchar](255) NOT NULL,
	[char_guildOffNote] [varchar](255) NOT NULL,
	[char_race] [tinyint] NOT NULL DEFAULT ((0)),
	[char_class] [tinyint] NOT NULL DEFAULT ((0)),
	[char_gender] [tinyint] NOT NULL DEFAULT ((0)),
	[char_skin] [tinyint] NOT NULL DEFAULT ((0)),
	[char_face] [tinyint] NOT NULL DEFAULT ((0)),
	[char_hairStyle] [tinyint] NOT NULL DEFAULT ((0)),
	[char_hairColor] [tinyint] NOT NULL DEFAULT ((0)),
	[char_facialHair] [tinyint] NOT NULL DEFAULT ((0)),
	[char_outfitId] [tinyint] NOT NULL DEFAULT ((0)),
	[char_restState] [tinyint] NOT NULL DEFAULT ((0)),
	[char_mana] [smallint] NOT NULL DEFAULT ((1)),
	[char_energy] [smallint] NOT NULL DEFAULT ((0)),
	[char_rage] [smallint] NOT NULL DEFAULT ((0)),
	[char_life] [smallint] NOT NULL DEFAULT ((1)),
	[char_manaType] [tinyint] NOT NULL DEFAULT ((0)),
	[char_strength] [tinyint] NOT NULL DEFAULT ((0)),
	[char_agility] [tinyint] NOT NULL DEFAULT ((0)),
	[char_stamina] [tinyint] NOT NULL DEFAULT ((0)),
	[char_intellect] [tinyint] NOT NULL DEFAULT ((0)),
	[char_spirit] [tinyint] NOT NULL DEFAULT ((0)),
	[char_copper] [int] NOT NULL DEFAULT ((0)),
	[char_watchedFactionIndex] [tinyint] NOT NULL DEFAULT ((255)),
	[char_reputation] [text] NOT NULL,
	[char_spellList] [varchar](255) NOT NULL,
	[char_skillList] [varchar](255) NOT NULL,
	[char_frendList] [varchar](255) NOT NULL,
	[char_ignoreList] [varchar](255) NOT NULL,
	[char_tutorialFlags] [varchar](255) NOT NULL,
	[char_actionBar] [varchar](255) NOT NULL,
	[char_mapExplored] [varchar](255) NOT NULL,
	[force_restrictions] [tinyint] NOT NULL DEFAULT ((0)),
	[char_talentpoints] [tinyint] NOT NULL DEFAULT ((0)),
	[char_bankslots] [tinyint] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_adb_characters] PRIMARY KEY CLUSTERED 
(
	[char_guid] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO