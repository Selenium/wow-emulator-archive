/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.14 11:42:40
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for tmpspawnedcorpses
#----------------------------
CREATE TABLE `tmpspawnedcoprses` (
  `corpse_guid` bigint(20) NOT NULL default '0',
  `corpse_owner` bigint(20) NOT NULL default '0',
  `corpse_positionX` double NOT NULL default '0',
  `corpse_positionY` double NOT NULL default '0',
  `corpse_positionZ` double NOT NULL default '0',
  `corpse_orientation` double NOT NULL default '0',
  `corpse_mapId` smallint(6) NOT NULL default '0',
  `corpse_bytes1` int(11) NOT NULL default '0',
  `corpse_bytes2` int(11) NOT NULL default '0',
  `corpse_model` smallint(6) NOT NULL default '0',
  `corpse_guild` smallint(6) NOT NULL default '0',
  `corpse_items` varchar(255) NOT NULL default '',
  PRIMARY KEY  (`corpse_guid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
#----------------------------
# No records for table tmpspawnedcoprses
#----------------------------


