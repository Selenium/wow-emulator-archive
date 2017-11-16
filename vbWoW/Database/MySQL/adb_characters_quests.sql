/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.29 13:59:13
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_characters_quests
#----------------------------
CREATE TABLE `adb_characters_quests` (
  `id` int(11) NOT NULL auto_increment,
  `char_guid` bigint(20) NOT NULL default '0',
  `quest_id` int(11) NOT NULL default '0',
  `quest_status` int(5) NOT NULL default '0',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
