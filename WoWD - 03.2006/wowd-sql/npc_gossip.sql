SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for npc_gossip
#----------------------------
CREATE TABLE `npc_gossip` (
  `ID` int(11) NOT NULL default '0',
  `NPC_GUID` int(11) NOT NULL default '0',
  `GOSSIP_TYPE` int(11) NOT NULL default '0',
  `TEXTID` int(30) NOT NULL default '0',
  `OPTION_COUNT` int(30) default NULL,
  PRIMARY KEY  (`ID`,`NPC_GUID`)
) TYPE=MyISAM;
#----------------------------
# Records for table npc_gossip
#----------------------------


insert  into npc_gossip values 
(1, 9, 1, 1, 1);

