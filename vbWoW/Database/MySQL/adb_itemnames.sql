/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.21-community-nt
Source Database:       awowedb
Date:                  2006/09/02 12:12:53
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_itemnames
#----------------------------
CREATE TABLE `adb_itemnames` (
  `itemID` smallint(6) NOT NULL default '0',
  `itemName` text NOT NULL,
  `itemWDBVersion` smallint(6) NOT NULL default '0',
  `itemChecksum` int(6) NOT NULL default '0',
  PRIMARY KEY  (`itemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='InnoDB free: 4096 kB';
#----------------------------
# No records for table adb_itemnames
#----------------------------


