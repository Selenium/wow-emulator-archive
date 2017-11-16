CREATE TABLE `accounts` (
  `acct` bigint(20) NOT NULL auto_increment,
  `login` varchar(255) NOT NULL default '',
  `password` varchar(28) NOT NULL default '',
  `s` longtext NOT NULL,
  `v` longtext NOT NULL,
  `gm` tinyint(1) NOT NULL default '0',
  `sessionkey` longtext NOT NULL,
  `email` varchar(50) NOT NULL default '',
  `joindate` timestamp(14) NOT NULL,
  PRIMARY KEY  (`acct`),
  UNIQUE KEY `acct` (`acct`)
) TYPE=MyISAM COMMENT='InnoDB free: 11264 kB; InnoDB free: 18432 kB';
