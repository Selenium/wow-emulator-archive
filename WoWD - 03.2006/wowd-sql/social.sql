SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for social
#----------------------------
CREATE TABLE `social` (
  `guid` int(6) NOT NULL default '0',
  `friendid` int(6) NOT NULL default '0',
  `flags` varchar(21) NOT NULL default ''
) TYPE=MyISAM;
#----------------------------
# No records for table social
#----------------------------


