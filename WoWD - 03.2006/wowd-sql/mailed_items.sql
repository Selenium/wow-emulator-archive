SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for mailed_items
#----------------------------
CREATE TABLE `mailed_items` (
  `guid` bigint(20) NOT NULL default '0',
  `data` longtext NOT NULL,
  PRIMARY KEY  (`guid`)
) TYPE=MyISAM;
#----------------------------
# No records for table mailed_items
#----------------------------


