SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for inventory
#----------------------------
CREATE TABLE `inventory` (
  `player_guid` bigint(20) NOT NULL default '0',
  `slot` int(11) NOT NULL default '0',
  `item_guid` bigint(20) NOT NULL default '0',
  PRIMARY KEY  (`item_guid`)
) TYPE=MyISAM;
#----------------------------
# No records for table inventory
#----------------------------


