SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for playercharters
#----------------------------
CREATE TABLE `playercharters` (
  `playerId` bigint(20) NOT NULL default '0',
  `charterId` bigint(20) NOT NULL default '0',
  PRIMARY KEY  (`playerId`),
  UNIQUE KEY `playerId` (`playerId`)
) TYPE=MyISAM COMMENT='InnoDB free: 11264 kB; InnoDB free: 18432 kB';
#----------------------------
# Records for table playercharters
#----------------------------

