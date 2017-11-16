/*
MySQL Data Transfer
Source Host: localhost
Source Database: awowedb
Target Host: localhost
Target Database: awowedb
Date: 27.10.2006 00:03:07
*/

SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for adb_items
#----------------------------
CREATE TABLE `adb_items` (
  `item_id` mediumint(3) NOT NULL default '0',
  `item_availableClasses` smallint(2) NOT NULL default '0',
  `item_availableRaces` smallint(2) NOT NULL default '0',
  `item_model` int(2) NOT NULL default '0',
  `item_class` tinyint(1) unsigned NOT NULL default '0',
  `item_subclass` tinyint(1) unsigned NOT NULL default '0',
  `item_level` tinyint(1) unsigned NOT NULL default '0',
  `item_requiredLevel` tinyint(1) unsigned NOT NULL default '0',
  `item_requiredSkill` tinyint(1) unsigned NOT NULL default '0',
  `item_requiredSkillRank` tinyint(1) unsigned NOT NULL default '0',
  `item_requiredSpell` tinyint(1) unsigned NOT NULL default '0',
  `item_requiredFaction` smallint(1) NOT NULL default '0',
  `item_requiredFactionLevel` tinyint(1) unsigned NOT NULL default '0',
  `item_requiredHonorRank` tinyint(1) unsigned NOT NULL default '0',
  `item_name` varchar(255) NOT NULL default '',
  `item_quality` tinyint(1) unsigned NOT NULL default '0',
  `item_sheath` tinyint(1) unsigned NOT NULL default '0',
  `item_buyPrice` mediumint(3) NOT NULL default '0',
  `item_sellPrice` mediumint(3) NOT NULL default '0',
  `item_inventoryType` tinyint(1) unsigned NOT NULL default '0',
  `item_stackable` tinyint(1) unsigned NOT NULL default '0',
  `item_material` smallint(1) NOT NULL default '0',
  `item_durability` smallint(2) NOT NULL default '0',
  `item_containerSlots` tinyint(1) unsigned NOT NULL default '0',
  `item_ammoType` tinyint(1) unsigned NOT NULL default '0',
  `item_block` smallint(2) NOT NULL default '0',
  `item_bonding` tinyint(1) unsigned NOT NULL default '0',
  `item_delay` smallint(2) NOT NULL default '0',
  `item_description` varchar(255) NOT NULL default '',
  `item_set` tinyint(1) unsigned NOT NULL default '0',
  `item_extra` smallint(2) NOT NULL default '0',
  `item_flags` smallint(2) NOT NULL default '0',
  `item_language` tinyint(1) unsigned NOT NULL default '0',
  `item_lockid` smallint(2) NOT NULL default '0',
  `item_pageMaterial` tinyint(1) unsigned NOT NULL default '0',
  `item_pageText` smallint(2) NOT NULL default '0',
  `item_maxCount` tinyint(1) unsigned NOT NULL default '0',
  `item_armor` smallint(2) NOT NULL default '0',
  `item_resHoly` smallint(2) NOT NULL default '0',
  `item_resFire` smallint(2) NOT NULL default '0',
  `item_resNature` smallint(2) NOT NULL default '0',
  `item_resFrost` smallint(2) NOT NULL default '0',
  `item_resShadow` smallint(2) NOT NULL default '0',
  `item_resArcane` smallint(2) NOT NULL default '0',
  `item_startQuest` smallint(2) NOT NULL default '0',
  `item_bonusHealth` tinyint(1) unsigned NOT NULL default '0',
  `item_bonusMana` tinyint(1) unsigned NOT NULL default '0',
  `item_bonusAgility` tinyint(1) unsigned NOT NULL default '0',
  `item_bonusStrength` tinyint(1) unsigned NOT NULL default '0',
  `item_bonusIntellect` tinyint(1) unsigned NOT NULL default '0',
  `item_bonusSpirit` tinyint(1) unsigned NOT NULL default '0',
  `item_bonusStamina` tinyint(1) unsigned NOT NULL default '0',
  `item_socketBonus` mediumint(9) NOT NULL default '0',
  `item_socket1` tinyint(3) unsigned NOT NULL default '0',
  `item_socket2` tinyint(3) unsigned NOT NULL default '0',
  `item_socket3` tinyint(3) unsigned NOT NULL default '0',
  `item_bagFamily` tinyint(3) unsigned NOT NULL default '0',
  `item_gemID` tinyint(3) unsigned NOT NULL default '0',
  `item_rangeMod` tinyint(3) unsigned NOT NULL default '0',
  `item_damage` varchar(255) NOT NULL default '',
  `item_spells` varchar(255) NOT NULL default '',
  `item_loot` mediumint(9) NOT NULL,
  PRIMARY KEY  (`item_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
#----------------------------
# Records for table adb_accounts
#----------------------------

#----------------------------
# Guild petition item
#----------------------------
INSERT INTO adb_items
  (item_id, item_availableClasses, item_availableRaces, item_model, item_class, item_subclass, item_level, item_requiredLevel, item_requiredSkill, item_requiredSkillRank, item_requiredSpell, item_requiredFaction, item_requiredFactionLevel, item_requiredHonorRank, item_name, item_quality, item_sheath, item_buyPrice, item_sellPrice, item_inventoryType, item_stackable, item_material, item_durability, item_containerSlots, item_ammoType, item_block, item_bonding, item_delay, item_description, item_set, item_extra, item_flags, item_language, item_lockid, item_pageMaterial, item_pageText, item_maxCount, item_armor, item_resHoly, item_resFire, item_resNature, item_resFrost, item_resShadow, item_resArcane, item_startQuest, item_bonusHealth, item_bonusMana, item_bonusAgility, item_bonusStrength, item_bonusIntellect, item_bonusSpirit, item_bonusStamina, item_damage, item_spells, item_loot)
VALUES
  (5863, 32767, 2047, 16161, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Guild Charter", 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, "", 0, 0, 8192, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "0:0:0 0:0:0 0:0:0 0:0:0 0:0:0", "0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0", 0);

#----------------------------
# Mail Stationery items
#----------------------------
INSERT INTO adb_items
  (item_id, item_availableClasses, item_availableRaces, item_model, item_class, item_subclass, item_level, item_requiredLevel, item_requiredSkill, item_requiredSkillRank, item_requiredSpell, item_requiredFaction, item_requiredFactionLevel, item_requiredHonorRank, item_name, item_quality, item_sheath, item_buyPrice, item_sellPrice, item_inventoryType, item_stackable, item_material, item_durability, item_containerSlots, item_ammoType, item_block, item_bonding, item_delay, item_description, item_set, item_extra, item_flags, item_language, item_lockid, item_pageMaterial, item_pageText, item_maxCount, item_armor, item_resHoly, item_resFire, item_resNature, item_resFrost, item_resShadow, item_resArcane, item_startQuest, item_bonusHealth, item_bonusMana, item_bonusAgility, item_bonusStrength, item_bonusIntellect, item_bonusSpirit, item_bonusStamina, item_damage, item_spells, item_loot)
VALUES
  (8164, 32767, 2047, 1069, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Test Stationery", 1, 0, 10, 2, 0, 10, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "0:0:0 0:0:0 0:0:0 0:0:0 0:0:0", "0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0", 0);
INSERT INTO adb_items
  (item_id, item_availableClasses, item_availableRaces, item_model, item_class, item_subclass, item_level, item_requiredLevel, item_requiredSkill, item_requiredSkillRank, item_requiredSpell, item_requiredFaction, item_requiredFactionLevel, item_requiredHonorRank, item_name, item_quality, item_sheath, item_buyPrice, item_sellPrice, item_inventoryType, item_stackable, item_material, item_durability, item_containerSlots, item_ammoType, item_block, item_bonding, item_delay, item_description, item_set, item_extra, item_flags, item_language, item_lockid, item_pageMaterial, item_pageText, item_maxCount, item_armor, item_resHoly, item_resFire, item_resNature, item_resFrost, item_resShadow, item_resArcane, item_startQuest, item_bonusHealth, item_bonusMana, item_bonusAgility, item_bonusStrength, item_bonusIntellect, item_bonusSpirit, item_bonusStamina, item_damage, item_spells, item_loot)
VALUES
  (9311, 32767, 2047, 7798, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Default Stationery", 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "0:0:0 0:0:0 0:0:0 0:0:0 0:0:0", "0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0", 0);
INSERT INTO adb_items
  (item_id, item_availableClasses, item_availableRaces, item_model, item_class, item_subclass, item_level, item_requiredLevel, item_requiredSkill, item_requiredSkillRank, item_requiredSpell, item_requiredFaction, item_requiredFactionLevel, item_requiredHonorRank, item_name, item_quality, item_sheath, item_buyPrice, item_sellPrice, item_inventoryType, item_stackable, item_material, item_durability, item_containerSlots, item_ammoType, item_block, item_bonding, item_delay, item_description, item_set, item_extra, item_flags, item_language, item_lockid, item_pageMaterial, item_pageText, item_maxCount, item_armor, item_resHoly, item_resFire, item_resNature, item_resFrost, item_resShadow, item_resArcane, item_startQuest, item_bonusHealth, item_bonusMana, item_bonusAgility, item_bonusStrength, item_bonusIntellect, item_bonusSpirit, item_bonusStamina, item_damage, item_spells, item_loot)
VALUES
  (18154, 32767, 2047, 30658, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Blizzard Stationery", 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "0:0:0 0:0:0 0:0:0 0:0:0 0:0:0", "0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0", 0);
INSERT INTO adb_items
  (item_id, item_availableClasses, item_availableRaces, item_model, item_class, item_subclass, item_level, item_requiredLevel, item_requiredSkill, item_requiredSkillRank, item_requiredSpell, item_requiredFaction, item_requiredFactionLevel, item_requiredHonorRank, item_name, item_quality, item_sheath, item_buyPrice, item_sellPrice, item_inventoryType, item_stackable, item_material, item_durability, item_containerSlots, item_ammoType, item_block, item_bonding, item_delay, item_description, item_set, item_extra, item_flags, item_language, item_lockid, item_pageMaterial, item_pageText, item_maxCount, item_armor, item_resHoly, item_resFire, item_resNature, item_resFrost, item_resShadow, item_resArcane, item_startQuest, item_bonusHealth, item_bonusMana, item_bonusAgility, item_bonusStrength, item_bonusIntellect, item_bonusSpirit, item_bonusStamina, item_damage, item_spells, item_loot)
VALUES
  (21140, 32767, 2047, 1102, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Auction Stationery", 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "0:0:0 0:0:0 0:0:0 0:0:0 0:0:0", "0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0", 0);
INSERT INTO adb_items
  (item_id, item_availableClasses, item_availableRaces, item_model, item_class, item_subclass, item_level, item_requiredLevel, item_requiredSkill, item_requiredSkillRank, item_requiredSpell, item_requiredFaction, item_requiredFactionLevel, item_requiredHonorRank, item_name, item_quality, item_sheath, item_buyPrice, item_sellPrice, item_inventoryType, item_stackable, item_material, item_durability, item_containerSlots, item_ammoType, item_block, item_bonding, item_delay, item_description, item_set, item_extra, item_flags, item_language, item_lockid, item_pageMaterial, item_pageText, item_maxCount, item_armor, item_resHoly, item_resFire, item_resNature, item_resFrost, item_resShadow, item_resArcane, item_startQuest, item_bonusHealth, item_bonusMana, item_bonusAgility, item_bonusStrength, item_bonusIntellect, item_bonusSpirit, item_bonusStamina, item_damage, item_spells, item_loot)
VALUES
  (22058, 32767, 2047, 1102, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Valentine's Day Stationery", 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "0:0:0 0:0:0 0:0:0 0:0:0 0:0:0", "0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0 0:0:0:0:0:0", 0);

