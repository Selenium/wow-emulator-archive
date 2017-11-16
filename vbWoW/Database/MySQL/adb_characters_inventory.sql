/*
MySQL Backup
Source Host:           localhost
Source Server Version: 5.0.21-community
Source Database:       awowedb
Date:                  2006.09.09 00:28:58
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_characters_inventory
#----------------------------
CREATE TABLE `adb_characters_inventory` (
  `item_guid` bigint(8) NOT NULL default '0',
  `item_id` smallint(2) NOT NULL default '0',
  `item_slot` tinyint(6) unsigned NOT NULL default '255',
  `item_bag` bigint(8) NOT NULL default '-1',
  `item_owner` bigint(8) NOT NULL default '0',
  `item_creator` bigint(8) NOT NULL default '0',
  `item_giftCreator` bigint(8) NOT NULL default '0',
  `item_stackCount` tinyint(1) unsigned NOT NULL default '0',
  `item_durability` smallint(2) NOT NULL default '0',
  `item_flags` smallint(11) NOT NULL default '0',
  `item_chargesLeft` tinyint(1) unsigned NOT NULL default '0',
  `item_textId` smallint(6) NOT NULL default '0',
  `item_enchantment` varchar(255) NOT NULL default '',
  `item_random_properties` smallint(6) NOT NULL default '0',
  PRIMARY KEY  (`item_guid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
#----------------------------
# Records for table adb_characters_inventory
#----------------------------

