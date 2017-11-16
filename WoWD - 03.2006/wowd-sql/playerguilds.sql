
SET FOREIGN_KEY_CHECKS=0;
use wowd;
#----------------------------
# Table structure for playerguilds
#----------------------------
CREATE TABLE `playerguilds` (
  `playerId` bigint(20) NOT NULL default '0',
  `guildId` bigint(20) NOT NULL default '0',
  `name` varchar(21) NOT NULL default '',
  `guildRank` int(10) NOT NULL default '0',
  `publicNote` varchar(100) NOT NULL default '',
  `officerNote` varchar(100) NOT NULL default '',
  `lastOnline` bigint(20) NOT NULL default '0',
  `lastClass` int(2) NOT NULL,
  `lastLevel` int(2) NOT NULL,
  `lastZone` int(4) NOT NULL,
  PRIMARY KEY  (`playerId`),
  UNIQUE KEY `playerId` (`playerId`)
) TYPE=MyISAM;
#----------------------------
# Records for table playerguilds
#----------------------------
