CREATE TABLE `trainer` (
  `GUID` int(32) unsigned NOT NULL default '0',
  `skillline1` int(32) unsigned NOT NULL default '0',
  `skillline2` int(32) unsigned NOT NULL default '0',
  `skillline3` int(32) unsigned NOT NULL default '0',
  `maxlvl` int(32) unsigned NOT NULL default '0',
  `class` int(32) unsigned NOT NULL default '0'
) TYPE=MyISAM;
