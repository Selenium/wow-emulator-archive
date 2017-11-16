SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for firewall
#----------------------------
CREATE TABLE `firewall` (
  `ip` char(20) NOT NULL default '',
  `allow` smallint(2) NOT NULL default '0',
  PRIMARY KEY  (`ip`)
) TYPE=MyISAM;
#----------------------------
# No records for table firewall
#----------------------------


