SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for ipbantable
#----------------------------
CREATE TABLE `ipbantable` (
  `ip` varchar(32) NOT NULL default '',
  `banned` tinyint(1) NOT NULL default '0',                           
  `countToBan` int(6) NOT NULL default '0',                           
  `banTime` int(11) NOT NULL default '0', 
  PRIMARY KEY  (`ip`),
  UNIQUE KEY `ip` (`ip`)
) TYPE=MyISAM COMMENT='InnoDB free: 11264 kB; InnoDB free: 18432 kB';
#----------------------------
# No records for table ipbantable
#----------------------------


