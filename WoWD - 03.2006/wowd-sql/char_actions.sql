SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for char_actions
#----------------------------
CREATE TABLE `char_actions` (
  `charId` int(6) NOT NULL default '0',
  `button` int(2) unsigned NOT NULL default '0',
  `action` int(6) unsigned NOT NULL default '0',
  `type` int(3) unsigned NOT NULL default '0',
  `misc` int(3) NOT NULL default '0'
) TYPE=MyISAM;
#----------------------------
# No records for table char_actions
#----------------------------


