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
  PRIMARY KEY  (`guid`)
) TYPE=MyISAM;