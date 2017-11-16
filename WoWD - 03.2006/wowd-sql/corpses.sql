SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for corpses
#----------------------------
CREATE TABLE `corpses` (
  `guid` bigint(20) unsigned NOT NULL default '0',
  `positionX` float NOT NULL default '0',
  `positionY` float NOT NULL default '0',
  `positionZ` float NOT NULL default '0',
  `orientation` float NOT NULL default '0',
  `zoneId` int(11) NOT NULL default '38',
  `mapId` int(11) NOT NULL default '0',
  `data` longtext NOT NULL,
  PRIMARY KEY  (`guid`)
) TYPE=MyISAM COMMENT='InnoDB free: 18432 kB';
#----------------------------
# No records for table corpses
#----------------------------


