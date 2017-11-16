SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for trainer
#----------------------------
CREATE TABLE `trainer` (
  `GUID` int(32) unsigned NOT NULL default '0',
  `skillline1` int(32) unsigned NOT NULL default '0',
  `skillline2` int(32) unsigned NOT NULL default '0',
  `skillline3` int(32) unsigned NOT NULL default '0',
  `maxlvl` int(32) unsigned NOT NULL default '0',
  `class` int(32) unsigned NOT NULL default '0'
) TYPE=MyISAM;
#----------------------------
# No records for table trainer
#----------------------------


