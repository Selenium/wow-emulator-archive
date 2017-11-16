/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.14 11:39:32
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_gameobjects
#----------------------------
CREATE TABLE `adb_gameobjects` (
  `gameObject_ID` mediumint(6) NOT NULL default '0',
  `gameObject_Size` double NOT NULL default '0',
  `gameObject_Model` smallint(6) NOT NULL default '0',
  `gameObject_Flags` smallint(6) NOT NULL default '0',
  `gameObject_Name` varchar(255) NOT NULL default '',
  `gameObject_Type` tinyint(3) unsigned NOT NULL default '0',
  `gameObject_Faction` mediumint(6) NOT NULL default '0',
  `gameObject_Sound0` mediumint(6) NOT NULL default '0',
  `gameObject_Sound1` mediumint(6) NOT NULL default '0',
  `gameObject_Sound2` mediumint(6) NOT NULL default '0',
  `gameObject_Sound3` mediumint(6) NOT NULL default '0',
  `gameObject_Sound4` mediumint(6) NOT NULL default '0',
  `gameObject_Sound5` mediumint(6) NOT NULL default '0',
  `gameObject_Sound6` mediumint(6) NOT NULL default '0',
  `gameObject_Sound7` mediumint(6) NOT NULL default '0',
  `gameObject_Sound8` mediumint(6) NOT NULL default '0',
  `gameObject_Sound9` mediumint(6) NOT NULL default '0',
  `gameObject_Loot` smallint(6) NOT NULL default '0',
  PRIMARY KEY  (`gameObject_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
#----------------------------
# Records for table adb_accounts
#----------------------------


#----------------------------
# Duel Flag Object Needed for Duels
#----------------------------
INSERT INTO adb_gameobjects
  (gameObject_ID, gameObject_Size, gameObject_Model, gameObject_Flags, gameObject_Name, gameObject_Type, gameObject_Faction, gameObject_Sound0, gameObject_Sound1, gameObject_Sound2, gameObject_Sound3, gameObject_Sound4, gameObject_Sound5, gameObject_Sound6, gameObject_Sound7, gameObject_Sound8, gameObject_Sound9, gameObject_Loot)
VALUES
  (21680, 1, 787, 0, "Duel Flag", 16, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
#----------------------------
# Fishing Bobber Object Needed for Fishing Skill
#----------------------------
INSERT INTO adb_gameobjects
  (gameObject_ID, gameObject_Size, gameObject_Model, gameObject_Flags, gameObject_Name, gameObject_Type, gameObject_Faction, gameObject_Sound0, gameObject_Sound1, gameObject_Sound2, gameObject_Sound3, gameObject_Sound4, gameObject_Sound5, gameObject_Sound6, gameObject_Sound7, gameObject_Sound8, gameObject_Sound9, gameObject_Loot)
VALUES
  (35591, 1, 668, 0, "Fishing Bobber", 17, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

