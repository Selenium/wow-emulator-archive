SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[adb_items]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adb_items](
	[item_id] [int] NOT NULL DEFAULT ((0)),
	[item_availableClasses] [smallint] NOT NULL DEFAULT ((0)),
	[item_availableRaces] [smallint] NOT NULL DEFAULT ((0)),
	[item_model] [int] NOT NULL DEFAULT ((0)),
	[item_class] [tinyint] NOT NULL DEFAULT ((0)),
	[item_subclass] [tinyint] NOT NULL DEFAULT ((0)),
	[item_level] [tinyint] NOT NULL DEFAULT ((0)),
	[item_requiredLevel] [tinyint] NOT NULL DEFAULT ((0)),
	[item_requiredSkill] [tinyint] NOT NULL DEFAULT ((0)),
	[item_requiredSkillRank] [tinyint] NOT NULL DEFAULT ((0)),
	[item_requiredSpell] [tinyint] NOT NULL DEFAULT ((0)),
	[item_requiredFaction] [smallint] NOT NULL DEFAULT ((0)),
	[item_requiredFactionLevel] [tinyint] NOT NULL DEFAULT ((0)),
	[item_requiredHonorRank] [tinyint] NOT NULL DEFAULT ((0)),
	[item_name] [varchar](255) NOT NULL,
	[item_quality] [tinyint] NOT NULL DEFAULT ((0)),
	[item_sheath] [tinyint] NOT NULL DEFAULT ((0)),
	[item_buyPrice] [int] NOT NULL DEFAULT ((0)),
	[item_sellPrice] [int] NOT NULL DEFAULT ((0)),
	[item_inventoryType] [tinyint] NOT NULL DEFAULT ((0)),
	[item_stackable] [tinyint] NOT NULL DEFAULT ((0)),
	[item_material] [smallint] NOT NULL DEFAULT ((0)),
	[item_durability] [smallint] NOT NULL DEFAULT ((0)),
	[item_containerSlots] [tinyint] NOT NULL DEFAULT ((0)),
	[item_ammoType] [tinyint] NOT NULL DEFAULT ((0)),
	[item_block] [smallint] NOT NULL DEFAULT ((0)),
	[item_bonding] [tinyint] NOT NULL DEFAULT ((0)),
	[item_delay] [smallint] NOT NULL DEFAULT ((0)),
	[item_description] [varchar](255) NOT NULL,
	[item_set] [tinyint] NOT NULL DEFAULT ((0)),
	[item_extra] [smallint] NOT NULL DEFAULT ((0)),
	[item_flags] [smallint] NOT NULL DEFAULT ((0)),
	[item_language] [tinyint] NOT NULL DEFAULT ((0)),
	[item_lockid] [smallint] NOT NULL DEFAULT ((0)),
	[item_pageMaterial] [tinyint] NOT NULL DEFAULT ((0)),
	[item_pageText] [smallint] NOT NULL DEFAULT ((0)),
	[item_maxCount] [tinyint] NOT NULL DEFAULT ((0)),
	[item_armor] [smallint] NOT NULL DEFAULT ((0)),
	[item_resHoly] [smallint] NOT NULL DEFAULT ((0)),
	[item_resFire] [smallint] NOT NULL DEFAULT ((0)),
	[item_resNature] [smallint] NOT NULL DEFAULT ((0)),
	[item_resFrost] [smallint] NOT NULL DEFAULT ((0)),
	[item_resShadow] [smallint] NOT NULL DEFAULT ((0)),
	[item_resArcane] [smallint] NOT NULL DEFAULT ((0)),
	[item_startQuest] [smallint] NOT NULL DEFAULT ((0)),
	[item_bonusHealth] [tinyint] NOT NULL DEFAULT ((0)),
	[item_bonusMana] [tinyint] NOT NULL DEFAULT ((0)),
	[item_bonusAgility] [tinyint] NOT NULL DEFAULT ((0)),
	[item_bonusStrength] [tinyint] NOT NULL DEFAULT ((0)),
	[item_bonusIntellect] [tinyint] NOT NULL DEFAULT ((0)),
	[item_bonusSpirit] [tinyint] NOT NULL DEFAULT ((0)),
	[item_bonusStamina] [tinyint] NOT NULL DEFAULT ((0)),
	[item_damage] [varchar](255) NOT NULL,
	[item_spells] [varchar](255) NOT NULL,
 CONSTRAINT [PK_adb_items] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO