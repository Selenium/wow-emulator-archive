
SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for characters
-- ----------------------------
CREATE TABLE `characters` (
  `guid` int(6) unsigned NOT NULL default '0',
  `acct` bigint(20) unsigned NOT NULL default '0',
  `data` longtext NOT NULL,
  `name` varchar(21) NOT NULL default '',
  `positionX` float NOT NULL default '0',
  `positionY` float NOT NULL default '0',
  `positionZ` float NOT NULL default '0',
  `mapId` mediumint(8) unsigned NOT NULL default '0',
  `zoneId` mediumint(8) unsigned NOT NULL default '0',
  `orientation` float NOT NULL default '0',
  `taximask` longtext NOT NULL,
  `banned` int(6) unsigned NOT NULL default '0',
  `timestamp` text,
  `online` int(11) default NULL,
  `bindpositionX` float NOT NULL default '0',
  `bindpositionY` float NOT NULL default '0',
  `bindpositionZ` float NOT NULL default '0',
  `bindmapId` mediumint(8) unsigned NOT NULL default '0',
  `bindzoneId` mediumint(8) unsigned NOT NULL default '0',
  `isResting` int(3) NOT NULL default '0',
  `restState` int(5) NOT NULL default '0',
  `restTime` int(5) NOT NULL default '0',
  PRIMARY KEY  (`guid`)
) TYPE=MyISAM;

-- ----------------------------
-- Records 
-- ----------------------------
