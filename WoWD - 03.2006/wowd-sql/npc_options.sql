SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for npc_options
#----------------------------
CREATE TABLE `npc_options` (
  `ID` int(11) NOT NULL default '0',
  `GOSSIP_ID` int(11) NOT NULL default '0',
  `TYPE` int(5) default NULL,
  `OPTION` text NOT NULL,
  `NPC_TEXT_NEXTID` int(11) default '0',
  `SPECIAL` int(11) default NULL,
  PRIMARY KEY  (`ID`)
) TYPE=MyISAM;
#----------------------------
# Records for table npc_options
#----------------------------


insert  into npc_options values 
(0, 1, 0, 'Return me to life.', 0, 2);

