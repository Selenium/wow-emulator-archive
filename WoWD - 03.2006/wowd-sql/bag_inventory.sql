SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for bag_inventory
#----------------------------
CREATE TABLE `bag_inventory` (
  `player_guid` bigint(100) NOT NULL default '0',
  `bagslot` int(20) NOT NULL default '0',
  `slot` int(11) NOT NULL default '0',
  `item_guid` bigint(20) NOT NULL default '0',
  PRIMARY KEY  (`item_guid`)
) TYPE=MyISAM;
#----------------------------
# No records for table bag_inventory
#----------------------------


