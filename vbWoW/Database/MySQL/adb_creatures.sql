/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.14 11:39:03
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_creatures
#----------------------------
CREATE TABLE `adb_creatures` (
  `creature_id` mediumint(2) NOT NULL default '0',
  `creature_name` varchar(100) NOT NULL default '',
  `creature_guild` varchar(100) NOT NULL default '',
  `creature_model` mediumint(3) NOT NULL default '0',
  `creature_size` double NOT NULL default '0',
  `creature_life` smallint(2) NOT NULL default '0',
  `creature_mana` smallint(2) NOT NULL default '0',
  `creature_manaType` tinyint(1) unsigned NOT NULL default '0',
  `creature_elite` tinyint(1) unsigned NOT NULL default '0',
  `creature_faction` smallint(2) NOT NULL default '0',
  `creature_family` tinyint(1) unsigned NOT NULL default '0',
  `creature_type` tinyint(1) unsigned NOT NULL default '0',
  `creature_minDamage` double NOT NULL default '0',
  `creature_maxDamage` double NOT NULL default '0',
  `creature_minRangedDamage` double NOT NULL default '0',
  `creature_maxRangedDamage` double NOT NULL default '0',
  `creature_attackPower` smallint(2) NOT NULL default '0',
  `creature_rangedAttackPower` smallint(2) NOT NULL default '0',
  `creature_armor` tinyint(3) unsigned NOT NULL default '0',
  `creature_resHoly` tinyint(3) unsigned NOT NULL default '0',
  `creature_resFire` tinyint(3) unsigned NOT NULL default '0',
  `creature_resNature` tinyint(3) unsigned NOT NULL default '0',
  `creature_resFrost` tinyint(3) unsigned NOT NULL default '0',
  `creature_resShadow` tinyint(3) unsigned NOT NULL default '0',
  `creature_resArcane` tinyint(3) unsigned NOT NULL default '0',
  `creature_walkSpeed` double NOT NULL default '0',
  `creature_runSpeed` double NOT NULL default '0',
  `creature_baseAttackSpeed` smallint(2) NOT NULL default '0',
  `creature_baseRangedAttackSpeed` smallint(2) NOT NULL default '0',
  `creature_combatReach` double NOT NULL default '0',
  `creature_bondingRadius` double NOT NULL default '0',
  `creature_npcFlags` smallint(1) NOT NULL default '0',
  `creature_flags` mediumint(3) NOT NULL default '0',
  `creature_minLevel` tinyint(1) unsigned NOT NULL default '0',
  `creature_maxLevel` tinyint(1) unsigned NOT NULL default '0',
  `creature_loot` smallint(6) NOT NULL default '0',
  `creature_lootSkinning` smallint(6) NOT NULL default '0',
  `creature_sell` smallint(6) NOT NULL default '0',
  `creature_aiScript` varchar(255) NOT NULL default '',
  PRIMARY KEY  (`creature_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
