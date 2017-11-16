/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.14 11:39:48
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_loots
#----------------------------
CREATE TABLE `adb_loots` (
  `loot_id` mediumint(6) NOT NULL auto_increment,
  `loot_item` smallint(6) NOT NULL default '0',
  `loot_chance` double NOT NULL default '0',
  `loot_group` smallint(6) NOT NULL default '0',
  PRIMARY KEY  (`loot_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
