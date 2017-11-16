# Table "gm_tickets" DDL

CREATE TABLE `gm_tickets` (
  `guid` int(6) NOT NULL default '0',
  `type` int(2) NOT NULL default '0',
  `posX` float NOT NULL default '0',
  `posY` float NOT NULL default '0',
  `posZ` float NOT NULL default '0',
  `message` text NOT NULL,
  `timestamp` text,
  PRIMARY KEY  (`guid`)
) TYPE=MyISAM