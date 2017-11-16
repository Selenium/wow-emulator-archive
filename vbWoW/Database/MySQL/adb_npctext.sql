/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.14 11:39:54
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_npctext
#----------------------------
CREATE TABLE `adb_npctext` (
  `text_id` smallint(6) NOT NULL default '0',
  `text_dens_0` tinyint(3) unsigned NOT NULL default '0',
  `text_text_0_1` varchar(255) NOT NULL default '',
  `text_text_0_2` varchar(255) NOT NULL default '',
  `text_lang_0` tinyint(3) unsigned NOT NULL default '0',
  `text_emote_0_1` smallint(6) NOT NULL default '0',
  `text_delay_0_1` smallint(6) NOT NULL default '0',
  `text_emote_0_2` smallint(6) NOT NULL default '0',
  `text_delay_0_2` smallint(6) NOT NULL default '0',
  `text_emote_0_3` smallint(6) NOT NULL default '0',
  `text_delay_0_3` smallint(6) NOT NULL default '0',
  PRIMARY KEY  (`text_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
#----------------------------
# No records for table adb_npctext
#----------------------------


