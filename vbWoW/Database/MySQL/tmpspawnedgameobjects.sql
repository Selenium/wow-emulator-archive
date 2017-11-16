/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.14 11:42:47
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for tmpspawnedgameobjects
#----------------------------
CREATE TABLE `tmpspawnedgameobjects` (
  `gameObject_guid` bigint(20) NOT NULL default '0',
  `gameObject_entry` mediumint(6) NOT NULL default '0',
  `gameObject_rotation1` double NOT NULL default '0',
  `gameObject_rotation2` double NOT NULL default '0',
  `gameObject_rotation3` double NOT NULL default '0',
  `gameObject_rotation4` double NOT NULL default '0',
  `gameObject_positionX` double NOT NULL default '0',
  `gameObject_positionY` double NOT NULL default '0',
  `gameObject_positionZ` double NOT NULL default '0',
  `gameObject_orientation` double NOT NULL default '0',
  `gameObject_map` smallint(6) NOT NULL default '0',
  `gameObject_spawnId` smallint(6) NOT NULL default '0',
  PRIMARY KEY  (`gameObject_guid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
