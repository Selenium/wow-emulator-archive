/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.14 11:38:04
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_characters_tickets
#----------------------------
CREATE TABLE `adb_characters_tickets` (
  `char_guid` bigint(20) NOT NULL default '0',
  `ticket_text` text NOT NULL,
  `ticket_category` tinyint(3) unsigned NOT NULL default '0',
  PRIMARY KEY  (`char_guid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;


