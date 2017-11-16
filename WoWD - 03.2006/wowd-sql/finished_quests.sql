SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for finished_quests
#----------------------------
CREATE TABLE `finished_quests` (
  `player_guid` bigint(20) unsigned NOT NULL default '0',
  `quest_id` bigint(20) unsigned NOT NULL default '0',
  PRIMARY KEY  (`player_guid`,`quest_id`)
) TYPE=MyISAM;
#----------------------------
# Records for table finished_quests
#----------------------------

