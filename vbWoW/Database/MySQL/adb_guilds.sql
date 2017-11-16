/*
MySQL Data Transfer
Source Host: localhost
Source Database: awowedb
Target Host: localhost
Target Database: awowedb
Date: 03.10.2006 18:09:57
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for adb_guilds
-- ----------------------------
CREATE TABLE `adb_guilds` (
  `guild_id` int(11) NOT NULL auto_increment,
  `guild_name` varchar(255) NOT NULL,
  `guild_leader` int(11) NOT NULL default '0',
  `guild_MOTD` varchar(255) NOT NULL default '',
  `guild_info` varchar(255) NOT NULL default '',
  `guild_cYear` tinyint(3) unsigned NOT NULL default '0',
  `guild_cMonth` tinyint(3) unsigned NOT NULL default '0',
  `guild_cDay` tinyint(3) unsigned NOT NULL default '0',
  `guild_tEmblemStyle` tinyint(3) unsigned NOT NULL default '0',
  `guild_tEmblemColor` tinyint(3) unsigned NOT NULL default '0',
  `guild_tBorderStyle` tinyint(3) unsigned NOT NULL default '0',
  `guild_tBorderColor` tinyint(3) unsigned NOT NULL default '0',
  `guild_tBackgroundColor` tinyint(3) unsigned NOT NULL default '0',
  `guild_rank0` varchar(255) NOT NULL default 'Leader',
  `guild_rank0_Rights` int(11) NOT NULL default '61951',
  `guild_rank1` varchar(255) NOT NULL default 'Officer',
  `guild_rank1_Rights` int(11) NOT NULL default '67',
  `guild_rank2` varchar(255) NOT NULL default 'Veteran',
  `guild_rank2_Rights` int(11) NOT NULL default '67',
  `guild_rank3` varchar(255) NOT NULL default 'Member',
  `guild_rank3_Rights` int(11) NOT NULL default '67',
  `guild_rank4` varchar(255) NOT NULL default 'Initiate',
  `guild_rank4_Rights` int(11) NOT NULL default '67',
  `guild_rank5` varchar(255) NOT NULL default '',
  `guild_rank5_Rights` int(11) NOT NULL default '0',
  `guild_rank6` varchar(255) NOT NULL default '',
  `guild_rank6_Rights` int(11) NOT NULL default '0',
  `guild_rank7` varchar(255) NOT NULL default '',
  `guild_rank7_Rights` int(11) NOT NULL default '0',
  `guild_rank8` varchar(255) NOT NULL default '',
  `guild_rank8_Rights` int(11) NOT NULL default '0',
  `guild_rank9` varchar(255) NOT NULL default '',
  `guild_rank9_Rights` int(11) NOT NULL default '0',
  PRIMARY KEY  (`guild_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

