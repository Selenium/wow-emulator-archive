SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for trainertemplate
#----------------------------
CREATE TABLE `trainertemplate` (
  `subname` varchar(100) NOT NULL default '',
  `skillline1` int(4) NOT NULL default '0',
  `skillline2` int(4) NOT NULL default '0',
  `skillline3` int(4) NOT NULL default '0',
  `classid` int(2) NOT NULL default '0',
  `maxlvl` int(3) NOT NULL default '0',
  PRIMARY KEY  (`subname`)
) TYPE=MyISAM;
#----------------------------
# Records for table trainertemplate
#----------------------------


insert  into trainertemplate values 
('Druid Trainer', 574, 134, 573, 11, 60), 
('Hunter Trainer', 50, 163, 51, 3, 60), 
('Mage Trainer', 6, 237, 8, 8, 60), 
('Paladin Trainer', 594, 267, 184, 2, 60), 
('Priest Trainer', 613, 56, 78, 5, 60), 
('Rogue Trainer', 253, 38, 39, 4, 60), 
('Shaman Trainer', 375, 373, 374, 7, 60), 
('Warlock Trainer', 355, 354, 593, 9, 60), 
('Warrior Trainer', 26, 256, 257, 1, 60);

