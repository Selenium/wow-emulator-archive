/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.21-community-nt
Source Database:       awowedb
Date:                  2006/09/01 21:47:30
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_item_pages
#----------------------------
CREATE TABLE `adb_item_pages` (
  `pageId` smallint(6) NOT NULL default '0',
  `pageNext` smallint(6) NOT NULL default '0',
  `pageText` text NOT NULL,
  `pageWDBVersion` smallint(6) NOT NULL default '0',
  `pageChecksum` smallint(6) NOT NULL default '0',
  PRIMARY KEY  (`pageId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
#----------------------------
# No records for table adb_item_pages
#----------------------------


