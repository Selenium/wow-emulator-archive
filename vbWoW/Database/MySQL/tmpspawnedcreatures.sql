/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.14 11:42:44
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for tmpspawnedcreatures
#----------------------------
CREATE TABLE `tmpspawnedcreatures` (
  `spawned_guid` bigint(20) NOT NULL default '0',
  `spawned_positionX` double default NULL,
  `spawned_positionY` double default NULL,
  `spawned_positionZ` double default NULL,
  `spawned_orientation` double default NULL,
  `spawned_map` smallint(2) default NULL,
  `spawned_entry` mediumint(2) default NULL,
  `spawn_id` mediumint(9) default NULL,
  PRIMARY KEY  (`spawned_guid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

