SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for affects
#----------------------------
CREATE TABLE `affects` (
  `charId` int(30) NOT NULL PRIMARY KEY default '0',
  `spell` int(30) unsigned NOT NULL default '0',
  `dur` int(30) unsigned NOT NULL default '0') TYPE=MyISAM;
#----------------------------
# No records for table affects
#----------------------------


