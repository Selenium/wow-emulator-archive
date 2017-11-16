/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.14 11:42:31
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_spawns
#----------------------------
CREATE TABLE `adb_spawns` (
  `spawn_id` mediumint(6) NOT NULL auto_increment,
  `spawn_entry` mediumint(6) NOT NULL default '0',
  `spawn_time` smallint(6) NOT NULL default '0',
  `spawn_positionX` double NOT NULL default '0',
  `spawn_positionY` double NOT NULL default '0',
  `spawn_positionZ` double NOT NULL default '0',
  `spawn_orientation` double NOT NULL default '0',
  `spawn_spawned` tinyint(1) unsigned NOT NULL default '0',
  `spawn_range` smallint(5) NOT NULL default '0',
  `spawn_type` tinyint(1) unsigned NOT NULL default '0',
  `spawn_map` smallint(6) NOT NULL default '0',
  `spawn_left` smallint(6) NOT NULL default '0',
  `spawn_waypoints` smallint(6) NOT NULL default '0',
  PRIMARY KEY  (`spawn_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;


