SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for creaturespells
#----------------------------
CREATE TABLE `creaturespells` (
  `entryid` int(11) NOT NULL default '0',
  `spellid` int(11) NOT NULL default '0',
  PRIMARY KEY  (`entryid`,`spellid`)
) TYPE=MyISAM;
#----------------------------
# No records for table creaturespells
#----------------------------


