/*
MySQL Backup
Source Host:           localhost
Source Server Version: 5.0.21-community
Source Database:       awowedb
Date:                  2006.09.02 20:38:42
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_characters_mail
#----------------------------
CREATE TABLE `adb_characters_mail` (
  `mail_id` smallint(5) NOT NULL auto_increment,
  `mail_sender` bigint(20) NOT NULL default '0',
  `mail_receiver` bigint(20) NOT NULL default '0',
  `mail_type` tinyint(3) unsigned NOT NULL default '0',
  `mail_stationery` smallint(4) NOT NULL default '41',
  `mail_subject` varchar(255) NOT NULL default '',
  `mail_body` varchar(255) NOT NULL default '',
  `mail_item_guid` bigint(20) NOT NULL default '0',
  `mail_money` int(6) NOT NULL default '0',
  `mail_COD` smallint(6) NOT NULL default '0',
  `mail_time` smallint(6) NOT NULL default '30',
  `mail_read` tinyint(3) unsigned NOT NULL default '0',
  PRIMARY KEY  (`mail_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;


