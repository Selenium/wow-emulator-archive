SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_creatures]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_creatures](
	[creature_id] [int] NOT NULL DEFAULT ((0)),
	[creature_name] [varchar](100) NOT NULL,
	[creature_guild] [varchar](100) NOT NULL,
	[creature_model] [int] NOT NULL DEFAULT ((0)),
	[creature_size] [float] NOT NULL DEFAULT ((0)),
	[creature_life] [smallint] NOT NULL DEFAULT ((0)),
	[creature_mana] [smallint] NOT NULL DEFAULT ((0)),
	[creature_manaType] [tinyint] NOT NULL DEFAULT ((0)),
	[creature_elite] [tinyint] NOT NULL DEFAULT ((0)),
	[creature_faction] [smallint] NOT NULL DEFAULT ((0)),
	[creature_family] [tinyint] NOT NULL DEFAULT ((0)),
	[creature_type] [tinyint] NOT NULL DEFAULT ((0)),
	[creature_minDamage] [float] NOT NULL DEFAULT ((0)),
	[creature_maxDamage] [float] NOT NULL DEFAULT ((0)),
	[creature_minRangedDamage] [float] NOT NULL DEFAULT ((0)),
	[creature_maxRangedDamage] [float] NOT NULL DEFAULT ((0)),
	[creature_attackPower] [smallint] NOT NULL DEFAULT ((0)),
	[creature_rangedAttackPower] [smallint] NOT NULL DEFAULT ((0)),
	[creature_armor] [tinyint] NOT NULL DEFAULT ((0)),
	[creature_resHoly] [tinyint] NOT NULL DEFAULT ((0)),
	[creature_resFire] [tinyint] NOT NULL DEFAULT ((0)),
	[creature_resNature] [tinyint] NOT NULL DEFAULT ((0)),
	[creature_resFrost] [tinyint] NOT NULL DEFAULT ((0)),
	[creature_resShadow] [tinyint] NOT NULL DEFAULT ((0)),
	[creature_resArcane] [tinyint] NOT NULL DEFAULT ((0)),
	[creature_walkSpeed] [float] NOT NULL DEFAULT ((0)),
	[creature_runSpeed] [float] NOT NULL DEFAULT ((0)),
	[creature_baseAttackSpeed] [smallint] NOT NULL DEFAULT ((0)),
	[creature_baseRangedAttackSpeed] [smallint] NOT NULL DEFAULT ((0)),
	[creature_combatReach] [float] NOT NULL DEFAULT ((0)),
	[creature_bondingRadius] [float] NOT NULL DEFAULT ((0)),
	[creature_npcFlags] [smallint] NOT NULL DEFAULT ((0)),
	[creature_flags] [int] NOT NULL DEFAULT ((0)),
	[creature_minLevel] [tinyint] NOT NULL DEFAULT ((0)),
	[creature_maxLevel] [tinyint] NOT NULL DEFAULT ((0)),
	[creature_loot] [smallint] NOT NULL DEFAULT ((0)),
	[creature_lootSkinning] [smallint] NOT NULL DEFAULT ((0)),
	[creature_sell] [smallint] NOT NULL DEFAULT ((0)),
	[creature_aiScript] [varchar](255) NOT NULL,
 CONSTRAINT [PK_adb_creatures] PRIMARY KEY CLUSTERED 
(
	[creature_id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO