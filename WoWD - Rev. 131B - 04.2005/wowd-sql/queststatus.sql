
CREATE TABLE `queststatus` (
  `playerId` bigint(20) unsigned NOT NULL default '0',
  `questId` bigint(22) unsigned NOT NULL default '0',
  `status` bigint(20) unsigned NOT NULL default '0',
  `questMobCount1` bigint(20) unsigned NOT NULL default '0',
  `questMobCount2` bigint(20) unsigned NOT NULL default '0',
  `questMobCount3` bigint(20) unsigned NOT NULL default '0',
  `questMobCount4` bigint(20) unsigned NOT NULL default '0',
  `questItemCount1` bigint(20) unsigned NOT NULL default '0',
  `questItemCount2` bigint(20) unsigned NOT NULL default '0',
  `questItemCount3` bigint(20) unsigned NOT NULL default '0',
  `questItemCount4` bigint(20) unsigned NOT NULL default '0',
  `id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;
