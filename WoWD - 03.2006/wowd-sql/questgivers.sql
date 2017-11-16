SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for questgivers
#----------------------------
CREATE TABLE `questgivers` (
  `creature_id` bigint(20) unsigned NOT NULL default '0',
  `quest_id` bigint(20) unsigned NOT NULL default '0',
  `type` tinyint(3) unsigned NOT NULL default '0',
  PRIMARY KEY  (`creature_id`,`quest_id`,`type`)
) TYPE=MyISAM;
#----------------------------
# Records for table questgivers
#----------------------------

