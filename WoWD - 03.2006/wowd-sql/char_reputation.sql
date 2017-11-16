#----------------------------
# Table structure for char_reputation
#----------------------------
CREATE TABLE `char_reputation` (
  `charId` int(11) NOT NULL default '0',
  `factionId` int(11) NOT NULL default '0',
  `flag` varchar(255) NOT NULL default '',
  `standing` varchar(255) NOT NULL default '',
  PRIMARY KEY  (`charId`,`factionId`)
) TYPE=MyISAM;
#----------------------------
# Records for table char_reputation
#----------------------------