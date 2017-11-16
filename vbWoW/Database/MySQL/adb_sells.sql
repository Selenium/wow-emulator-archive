/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.14 11:42:24
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_sells
#----------------------------
CREATE TABLE `adb_sells` (
  `sell_id` mediumint(9) NOT NULL auto_increment,
  `sell_item` mediumint(9) NOT NULL default '0',
  `sell_count` tinyint(3) unsigned NOT NULL default '1',
  `sell_group` smallint(6) NOT NULL default '0',
  `sell_price` smallint(6) NOT NULL default '0',
  PRIMARY KEY  (`sell_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
