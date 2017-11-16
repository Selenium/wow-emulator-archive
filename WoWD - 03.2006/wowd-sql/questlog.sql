SET FOREIGN_KEY_CHECKS=0;
#----------------------------
# Table structure for questlog
#----------------------------
CREATE TABLE `questlog` (
  `index` bigint(20) unsigned NOT NULL auto_increment,
  `player_guid` bigint(20) unsigned NOT NULL default '0',
  `quest_id` bigint(20) unsigned NOT NULL default '0',
  `questgiver_guid` bigint(20) unsigned NOT NULL default '0',
  `item_entry_1` bigint(20) unsigned NOT NULL default '0',
  `item_entry_2` bigint(20) unsigned NOT NULL default '0',
  `item_entry_3` bigint(20) unsigned NOT NULL default '0',
  `item_entry_4` bigint(20) unsigned NOT NULL default '0',
  `item_picked_1` bigint(20) NOT NULL default '0',
  `item_picked_2` bigint(20) NOT NULL default '0',
  `item_picked_3` bigint(20) NOT NULL default '0',
  `item_picked_4` bigint(20) NOT NULL default '0',
  `mob_entry_1` bigint(20) NOT NULL default '0',
  `mob_entry_2` bigint(20) NOT NULL default '0',
  `mob_entry_3` bigint(20) NOT NULL default '0',
  `mob_entry_4` bigint(20) NOT NULL default '0',
  `mob_killed_1` bigint(20) NOT NULL default '0',
  `mob_killed_2` bigint(20) NOT NULL default '0',
  `mob_killed_3` bigint(20) NOT NULL default '0',
  `mob_killed_4` bigint(20) NOT NULL default '0',
  PRIMARY KEY  (`index`),
  KEY `index` (`index`)
) TYPE=MyISAM;
#----------------------------
# Records for table questlog
#----------------------------

