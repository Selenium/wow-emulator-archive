
CREATE TABLE `creatures` (
  `id` bigint(20) unsigned NOT NULL default '0',
  `positionX` float NOT NULL default '0',
  `positionY` float NOT NULL default '0',
  `positionZ` float NOT NULL default '0',
  `orientation` float NOT NULL default '0',
  `zoneId` int(11) NOT NULL default '38',
  `mapId` int(11) NOT NULL default '0',
  `data` longtext NOT NULL,
  `name_id` bigint(20) NOT NULL default '0',
  `moverandom` int(11) default '1',
  `running` int(11) default '0',
  PRIMARY KEY  (`id`)
) TYPE=MyISAM COMMENT='InnoDB free: 18432 kB';
