SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for npc_text
#----------------------------
CREATE TABLE `npc_text` (
  `ID` int(11) NOT NULL default '0',
  `TYPE_UNUSED` int(11) NOT NULL default '0',
  `TEXT` longtext NOT NULL,
  PRIMARY KEY  (`ID`)
) TYPE=MyISAM;
#----------------------------
# Records for table npc_text
#----------------------------


insert  into npc_text values 
(1, 0, 'It is not yet your time. I shall aid your journey back to the realm of the living...\r\nFor a price.');

