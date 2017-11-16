/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.14 11:39:59
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_realms
#----------------------------
CREATE TABLE `adb_realms` (
  `ws_name` varchar(50) NOT NULL default '',
  `ws_host` varchar(50) NOT NULL default '',
  `ws_port` int(5) NOT NULL default '0',
  `ws_status` tinyint(3) unsigned NOT NULL default '0',
  `ws_id` tinyint(3) unsigned NOT NULL default '0',
  `ws_type` tinyint(3) unsigned NOT NULL default '0',
  `ws_population` float(3,0) unsigned NOT NULL default '0',
  PRIMARY KEY  (`ws_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
#----------------------------
# Records for table adb_realms
#----------------------------


insert  into adb_realms values 
('Test Realm 1', '192.168.0.2', 8085, 0, 0, 0, '0'), 
('Loopback Realm 2', 'localhost', 3726, 2, 1, 1, '0');

