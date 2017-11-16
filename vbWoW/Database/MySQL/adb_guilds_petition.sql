/*
MySQL Backup
Source Host:           localhost
Source Server Version: 5.0.21-community
Source Database:       awowedb
Date:                  2006.09.05 21:39:32
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_guilds_petition
#----------------------------
CREATE TABLE `adb_guilds_petition` (
  `petition_id` int(11) NOT NULL,
  `petition_itemGuid` int(11) NOT NULL,
  `petition_owner` int(11) NOT NULL,
  `petition_name` varchar(255) NOT NULL,
  `petition_signedMembers` tinyint(3) unsigned NOT NULL,
  `petition_signedMember1` int(11) NOT NULL default '0',
  `petition_signedMember2` int(11) NOT NULL default '0',
  `petition_signedMember3` int(11) NOT NULL default '0',
  `petition_signedMember4` int(11) NOT NULL default '0',
  `petition_signedMember5` int(11) NOT NULL default '0',
  `petition_signedMember6` int(11) NOT NULL default '0',
  `petition_signedMember7` int(11) NOT NULL default '0',
  `petition_signedMember8` int(11) NOT NULL default '0',
  `petition_signedMember9` int(11) NOT NULL default '0',
  PRIMARY KEY  (`petition_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
#----------------------------
# Records for table adb_guilds_petition
#----------------------------

