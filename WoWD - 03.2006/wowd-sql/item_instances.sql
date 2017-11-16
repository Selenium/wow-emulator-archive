SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for item_instances
#----------------------------
CREATE TABLE `item_instances` (
  `guid` bigint(20) NOT NULL default '0',
  `data` longtext NOT NULL,
  PRIMARY KEY  (`guid`)
) TYPE=MyISAM;
#----------------------------
# No records for table item_instances
#----------------------------


