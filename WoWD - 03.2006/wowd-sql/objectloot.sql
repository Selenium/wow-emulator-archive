
SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for objectloot
#----------------------------
CREATE TABLE `objectloot` (
  `entryid` int(11) NOT NULL default '0',
  `itemid` int(11) NOT NULL default '0',
  `percentchance` float default NULL,
  PRIMARY KEY  (`entryid`)
) TYPE=MyISAM;
#----------------------------
# No records for table objectloot
#----------------------------


