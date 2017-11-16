SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for graveyards
#----------------------------
CREATE TABLE `graveyards` (
  `ID` int(60) NOT NULL auto_increment,
  `X` float default NULL,
  `Y` float default NULL,
  `Z` float default NULL,
  `O` float default NULL,
  `zoneId` int(16) default NULL,
  `mapId` int(16) default NULL,
  `faction_id` int(32) unsigned default NULL,
  PRIMARY KEY  (`ID`)
) TYPE=MyISAM;
#----------------------------
# Records for table graveyards
#----------------------------


insert  into graveyards values 
(1, '10387', '821.682', '1317.52', '0.486154', 141, 1, null);

