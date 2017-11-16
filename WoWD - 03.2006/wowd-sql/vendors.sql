SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for vendors
#----------------------------
CREATE TABLE `vendors` (
  `vendorGuid` bigint(20) unsigned NOT NULL default '0',
  `itemGuid` bigint(20) unsigned NOT NULL default '0',
  `amount` bigint(20) NOT NULL default '0'
) TYPE=MyISAM;
#----------------------------
# No records for table vendors
#----------------------------


