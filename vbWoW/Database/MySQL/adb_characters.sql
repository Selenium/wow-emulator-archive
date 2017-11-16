/*
MySQL Data Transfer
Source Host: localhost
Source Database: awowedb
Target Host: localhost
Target Database: awowedb
Date: 21.10.2006 14:49:18
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for adb_characters
-- ----------------------------
CREATE TABLE `adb_characters` (
  `account_id` mediumint(3) unsigned NOT NULL default '0',
  `char_guid` int(8) NOT NULL auto_increment,
  `char_name` varchar(21) NOT NULL default '',
  `char_level` tinyint(1) unsigned NOT NULL default '0',
  `char_xp` mediumint(3) NOT NULL default '0',
  `char_access` tinyint(1) unsigned NOT NULL default '0',
  `char_online` tinyint(1) unsigned NOT NULL default '0',
  `char_positionX` float NOT NULL default '0',
  `char_positionY` float NOT NULL default '0',
  `char_positionZ` float NOT NULL default '0',
  `char_map_id` smallint(2) NOT NULL default '0',
  `char_zone_id` smallint(2) NOT NULL default '0',
  `char_orientation` float NOT NULL default '0',
  `char_model` smallint(2) NOT NULL default '0',
  `bindpoint_positionX` float NOT NULL default '0',
  `bindpoint_positionY` float NOT NULL default '0',
  `bindpoint_positionZ` float NOT NULL default '0',
  `bindpoint_map_id` smallint(2) NOT NULL default '0',
  `bindpoint_zone_id` smallint(2) NOT NULL default '0',
  `char_guildId` int(1) NOT NULL default '0',
  `char_guildRank` tinyint(1) unsigned NOT NULL default '0',
  `char_guildPNote` varchar(255) NOT NULL default '',
  `char_guildOffNote` varchar(255) NOT NULL default '',
  `char_race` tinyint(1) unsigned NOT NULL default '0',
  `char_class` tinyint(1) unsigned NOT NULL default '0',
  `char_gender` tinyint(1) unsigned NOT NULL default '0',
  `char_skin` tinyint(1) unsigned NOT NULL default '0',
  `char_face` tinyint(1) unsigned NOT NULL default '0',
  `char_hairStyle` tinyint(1) unsigned NOT NULL default '0',
  `char_hairColor` tinyint(1) unsigned NOT NULL default '0',
  `char_facialHair` tinyint(1) unsigned NOT NULL default '0',
  `char_outfitId` tinyint(1) unsigned NOT NULL default '0',
  `char_restState` tinyint(1) unsigned NOT NULL default '0',
  `char_mana` smallint(2) NOT NULL default '1',
  `char_energy` smallint(2) NOT NULL default '0',
  `char_rage` smallint(2) NOT NULL default '0',
  `char_life` smallint(2) NOT NULL default '1',
  `char_manaType` tinyint(1) unsigned NOT NULL default '0',
  `char_strength` tinyint(1) unsigned NOT NULL default '0',
  `char_agility` tinyint(1) unsigned NOT NULL default '0',
  `char_stamina` tinyint(1) unsigned NOT NULL default '0',
  `char_intellect` tinyint(1) unsigned NOT NULL default '0',
  `char_spirit` tinyint(1) unsigned NOT NULL default '0',
  `char_copper` mediumint(3) NOT NULL default '0',
  `char_watchedFactionIndex` tinyint(1) unsigned NOT NULL default '255',
  `char_reputation` text NOT NULL,
  `char_spellList` varchar(255) NOT NULL default '',
  `char_skillList` varchar(255) NOT NULL default '',
  `char_frendList` varchar(255) NOT NULL default '',
  `char_ignoreList` varchar(255) NOT NULL default '',
  `char_tutorialFlags` varchar(255) NOT NULL default '',
  `char_actionBar` varchar(255) NOT NULL default '',
  `char_mapExplored` varchar(255) NOT NULL default '',
  `force_restrictions` tinyint(1) unsigned NOT NULL default '0',
  `char_talentPoints` tinyint(1) unsigned NOT NULL default '0',
  `char_bankSlots` tinyint(1) unsigned NOT NULL default '0',
  PRIMARY KEY  (`char_guid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

