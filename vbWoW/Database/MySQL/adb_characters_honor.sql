/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.14 11:37:50
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_characters_honor
#----------------------------
CREATE TABLE `adb_characters_honor` (
  `char_guid` bigint(20) NOT NULL default '0',
  `arena_currency` smallint(6) NOT NULL default '0',
  `honor_currency` smallint(6) NOT NULL default '0',
  `honor_title` tinyint(3) unsigned NOT NULL default '0',
  `honor_knownTitles` smallint(4) NOT NULL default '0',
  `honor_killsToday` smallint(11) NOT NULL default '0',
  `honor_killsYesterday` smallint(11) NOT NULL default '0',
  `honor_pointsToday` smallint(11) NOT NULL default '0',
  `honor_pointsYesterday` smallint(11) NOT NULL default '0',
  `honor_kills` mediumint(11) NOT NULL default '0',
  PRIMARY KEY  (`char_guid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
