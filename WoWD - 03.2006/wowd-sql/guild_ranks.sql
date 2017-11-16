/*
MySQL Backup
Source Host:           localhost
Source Server Version: 5.0.18-nt
Source Database:       wowd
Date:                  2006/02/12 18:34:03
*/

SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for guild_ranks
#----------------------------
CREATE TABLE `guild_ranks` (
  `guildId` int(6) unsigned NOT NULL default '0',
  `rankId` int(1) NOT NULL,
  `rankName` varchar(255) NOT NULL default '',
  `rankRights` int(3) unsigned NOT NULL default '0'
) TYPE=MyISAM;
#----------------------------
# Records for table guild_ranks
#----------------------------
