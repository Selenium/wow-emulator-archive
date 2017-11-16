/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.14 11:42:35
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_weather
#----------------------------
CREATE TABLE `adb_weather` (
  `weather_zone` smallint(6) NOT NULL default '0',
  `weather_type` tinyint(3) unsigned NOT NULL default '0',
  `weather_intensity` double NOT NULL default '0',
  `weather_aviableTypes` varchar(255) NOT NULL default '0',
  PRIMARY KEY  (`weather_zone`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
#----------------------------
# Records for table adb_weather
#----------------------------


insert  into adb_weather values 
(12, 1, '0.33', '0'), 
(141, 2, '0.33', '0'), 
(14, 1, '0.1', '0'), 
(85, 1, '0.1', '0'), 
(1, 2, '0.2', '0'), 
(215, 1, '0.7', '0'), 
(184, 1, '0.1', '0'), 
(36, 1, '0.1', '0'), 
(33, 1, '0', '0'), 
(357, 1, '0', '0'), 
(490, 1, '0', '0'), 
(405, 2, '0', '0'), 
(440, 3, '0', '0'), 
(1377, 3, '0', '0'), 
(3429, 3, '0', '0');

