/*
MySQL Backup
Source Host:           localhost
Source Server Version: 4.1.8-nt
Source Database:       awowedb
Date:                  2006.07.14 11:35:54
*/

SET FOREIGN_KEY_CHECKS=0;
use awowedb;
#----------------------------
# Table structure for adb_accounts
#----------------------------
CREATE TABLE `adb_accounts` (
  `account` varchar(30) NOT NULL default '',
  `password` varchar(30) NOT NULL default '',
  `plevel` tinyint(1) unsigned NOT NULL default '0',
  `email` varchar(50) NOT NULL default '',
  `joindate` varchar(10) NOT NULL default '00-00-0000',
  `last_sshash` varchar(90) NOT NULL default '',
  `last_ip` varchar(15) NOT NULL default '',
  `last_login` varchar(100) NOT NULL default '0000-00-00',
  `banned` tinyint(1) unsigned NOT NULL default '0',
  `expansion` tinyint(1) unsigned NOT NULL default '1',
  `account_id` mediumint(3) NOT NULL auto_increment,
  PRIMARY KEY  (`account_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
#----------------------------
# Records for table adb_accounts
#----------------------------


insert  into adb_accounts values 
('TEST2', 'test', 2, 'test2@abv.bg', '2005-11-07', '93A8108915BF547DD60DAAC3B23A7083228BFB3910F9C53A5725AF6B99F10D763BB3F9A18E1474BA', '192.168.0.2', '2006-07-13', 0, 1, 2), 
('TEST', 'test', 2, 'test@abv.bg', '2006-01-17', 'CB3AA3ECC7343516C1339031BAB72226B53EE5110D5FAFF751AED88FB34516031F34C2553586CBE9', '192.168.0.1', '2006-07-13', 0, 0, 1);

