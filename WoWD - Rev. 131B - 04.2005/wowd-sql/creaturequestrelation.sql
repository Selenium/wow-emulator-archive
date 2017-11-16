
CREATE TABLE `creaturequestrelation` (
  `Id` int(6) unsigned NOT NULL auto_increment,
  `questId` bigint(20) unsigned NOT NULL default '0',
  `creatureId` bigint(20) unsigned NOT NULL default '0',
  PRIMARY KEY  (`Id`)
) TYPE=MyISAM COMMENT='Maps which creatures have which quests; InnoDB free: 18432 k';
