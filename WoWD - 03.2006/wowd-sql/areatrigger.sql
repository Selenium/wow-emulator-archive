SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for areatriggers
#----------------------------
CREATE TABLE `areatriggers` (
  `AreaTriggerid` bigint(20) NOT NULL default '0',
  `Type` int(100) default NULL,
  `Mapid` int(100) default NULL,
  `Screen` int(100) default NULL,
  `Name` varchar(100) default '0',
  `x` float NOT NULL default '0',
  `y` float NOT NULL default '0',
  `z` float NOT NULL default '0',
  PRIMARY KEY  (`AreaTriggerid`)
) TYPE=MyISAM;
