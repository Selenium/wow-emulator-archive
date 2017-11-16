SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for guilds
#----------------------------
CREATE TABLE `guilds` (
  `guildId` bigint(20) NOT NULL auto_increment,
  `guildName` varchar(32) NOT NULL default '',
  `leaderGuid` bigint(20) NOT NULL default '0',
  `emblemStyle` int(10) NOT NULL default '0',
  `emblemColor` int(10) NOT NULL default '0',
  `borderStyle` int(10) NOT NULL default '0',
  `borderColor` int(10) NOT NULL default '0',
  `backgroundColor` int(10) NOT NULL default '0',
  `guildInfo` varchar(100) NOT NULL,
  `motd` varchar(100) NOT NULL,
  `createdate` datetime NOT NULL,
  PRIMARY KEY  (`guildId`),
  UNIQUE KEY `guildId` (`guildId`)
) TYPE=MyISAM;
#----------------------------
# Records for table guilds
#----------------------------
