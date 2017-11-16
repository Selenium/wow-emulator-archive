
CREATE TABLE `firewall` (
  `ip` char(20) NOT NULL default '',
  `allow` smallint(2) NOT NULL default '0',
  PRIMARY KEY  (`ip`)
) TYPE=MyISAM;
