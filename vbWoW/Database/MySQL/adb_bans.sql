/*
MySQL Data Transfer
Source Host: localhost
Source Database: awowedb
Target Host: localhost
Target Database: awowedb
Date: 1/9/2007 4:31:46 AM
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for adb_bans
-- ----------------------------
CREATE TABLE `adb_bans` (
  `ip` varchar(100) NOT NULL default '',
  `date` date default '0000-00-00',
  `reason` varchar(100) default NULL,
  `who` varchar(100) default NULL,
  PRIMARY KEY  (`ip`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records 
-- ----------------------------
