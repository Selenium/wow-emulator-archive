CREATE TABLE `auctioned_items` (
  `guid` bigint(20) NOT NULL default '0',
  `data` longtext NOT NULL,
  PRIMARY KEY  (`guid`)
) TYPE=MyISAM;
